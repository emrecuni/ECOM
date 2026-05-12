using ECOM.API.Data;
using ECOM.API.Helpers;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.DTOs.Smtp;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IProductService _productService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(
            IProductService productService,
            IAuthService authService,
            IConfiguration config,
            DataContext context,
            ILogger<CustomerService> logger)
        {
            _productService = productService;
            _authService = authService;
            _config = config;
            _context = context;
            _logger = logger;
        }

        public async Task<Response<BasicCustomerResponseDto>> ChangeBasicInfo(BasicCustomerRequestDto model)
        {
            Response<BasicCustomerResponseDto> response = new();
            try
            {
                var customer = await _context.Customers
                    .Select(c => new Customers
                    {
                        CustomerId = c.CustomerId,
                        Name = c.Name,
                        Surname = c.Surname,
                        BirthDate = c.BirthDate
                    })
                    .FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId);

                if (customer is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri bulunamadı.";
                    return response;
                }

                // model'den gönderilen değerler null değilse mevcut müşteri bilgileri güncellenir, null ise mevcut bilgiler korunur
                customer.Name = model.Name ?? customer.Name;
                customer.Surname = model.Surname ?? customer.Surname;
                customer.BirthDate = model.BirthDate ?? customer.BirthDate;
                customer.Gender = model.Gender ?? customer.Gender;
                customer.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                response.Result = new BasicCustomerResponseDto
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    BirthDate = customer.BirthDate,
                    Gender = customer.Gender
                };
                response.Status = Status.Success;
                response.Message = "Müşteri bilgileri başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/ChangeBasicInfo ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<ContactInfoResponseDto>> ChangeContactInfo(ContactInfoRequestDto model)
        {
            Response<ContactInfoResponseDto> response = new();
            try
            {
                #region müşteriyi db'den çeker

                var customer = await _context.Customers
                    .Select(c => new Customers
                    {
                        CustomerId = c.CustomerId,
                        Phone = c.Phone,
                        Email = c.Email
                    })
                    .FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId);

                if (customer is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri bulunamadı.";
                    return response;
                }
                #endregion

                #region eski değerlerin doğruluğunu kontrol et
                if (model.OldEmail is not null && customer.Email != model.OldEmail || model.OldPhone is not null && customer.Phone != model.OldPhone)
                {
                    response.Status = Status.Failed;
                    response.Message = "Eski iletişim bilgileri yanlış.";
                    return response;
                }
                #endregion

                #region doğrulama kodu gönder
                OtpRequestDto request = new()
                {
                    Email = customer.Email!,
                    Purpose = OtpPurpose.ChangeEmail
                };
                var responseVerificationCode = await _authService.SendOTP(request);
                #endregion

                #region doğrulama kodunu kontrol et
                if (responseVerificationCode.Message is not null)
                {
                    var verificationCode = responseVerificationCode.Message.Substring(responseVerificationCode.Message.IndexOf(": ") + 2);

                    request.CodeHash = verificationCode;

                    var responseCheckVerify = await _authService.CheckOtpInDb(request);

                    if (responseCheckVerify.Status == Status.Success)
                    {
                        customer.Email = model.NewEmail ?? customer.Email;
                        customer.Phone = model.NewPhone ?? customer.Phone;
                        customer.UpdatedAt = DateTime.Now;
                        await _context.SaveChangesAsync();
                        response.Result = new ContactInfoResponseDto
                        {
                            CustomerId = customer.CustomerId,
                            NewEmail = customer.Email,
                            NewPhone = customer.Phone
                        };
                        response.Status = Status.Success;
                        response.Message = "Müşteri iletişim bilgileri başarıyla güncellendi.";
                    }
                    else
                    {
                        response.Status = Status.Failed;
                        response.Message = "Doğrulama kodu yanlış.";
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/ChangeBasicInfo ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<int>> ChangePassword(ChangePasswordRequestDto model)
        {
            Response<int> response = new();
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId);
                if (customer is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri bulunamadı.";
                    return response;
                }
                else if (EncryptionHelper.VerifyPassword(model.OldPassword, customer.Password!))
                {
                    if (model.NewPassword == model.ReNewPassword)
                    {
                        var hashedPassword = EncryptionHelper.HashPassword(model.NewPassword);
                        var updated = await _context.Customers
                            .Where(c => c.CustomerId == model.CustomerId)
                            .ExecuteUpdateAsync(c => c.SetProperty(p => p.Password, hashedPassword)
                                                        .SetProperty(p => p.UpdatedAt, DateTime.Now));
                        response.Result = updated;
                        response.Status = updated > 0 ? Status.Success : Status.Failed;
                        response.Message = updated > 0 ? "Şifre başarıyla değiştirildi." : "Şifre değiştirilirken bir hata oluştu.";
                    }
                    else
                    {
                        response.Status = Status.Failed;
                        response.Message = "Yeni şifreler eşleşmiyor.";
                    }
                }
                else
                {
                    response.Status = Status.Failed;
                    response.Message = "Eski şifre yanlış veya müşteri bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/ChangePassword ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetCouponsResponseDto>> GetCoupons(int customerId)
        {
            Response<GetCouponsResponseDto> response = new();
            try
            {
                var coupons = await _context.DCoupons
                    .Where(cc => cc.CustomerId == customerId)
                    .Include(cc => cc.Coupon)
                    .Select(cc => new CouponResponseDto
                    {
                        SCouponId = cc.Coupon.SCouponId,
                        Code = cc.Coupon.Code,
                        Amount = cc.Coupon.Amount,
                        ValidityDate = cc.Coupon.ValidityDate,
                        DCouponId = cc.DCouponId,
                        DefinitaionDate = cc.DefinitionDate,
                        Enable = cc.Enable,
                        LowerLimit = cc.Coupon.LowerLimit
                    })
                    .ToListAsync();

                response.Result = new GetCouponsResponseDto { CustomerId = customerId, Coupons = coupons };
                response.Status = coupons.Count > 0 ? Status.Success : Status.Failed;
                response.Message = coupons.Count > 0 ? $"{customerId} Id'li müşterinin kuponları başarıyla getirildi." : $"{customerId} Id'li müşterinin kuponu bulunamadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/GetCoupons ==> Error: {ex}");
                response.Result = new GetCouponsResponseDto { CustomerId = customerId, Coupons = null };
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<string>> AddFavorite(FavoriteRequestDto model)
        {
            Response<string> response = new();
            try
            {
                // gönderilen id'ye ait kullanıcı var mı kontrol eder
                if (!await _context.Customers.AnyAsync(c => c.CustomerId == model.CustomerId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri Bulunamadı.";
                    return response;
                }

                // gönderilen id'ye ait ürün var mı kontrol eder
                if (!await _context.Products.AnyAsync(p => p.ProductId == model.ProductId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Ürün Bulunamadı.";
                    return response;
                }

                // gönderilen customerid ve productid ile favori kaydı var mı kontrol eder
                if (await _context.Favorites.AnyAsync(f => f.CustomerId == model.CustomerId && f.ProductId == model.ProductId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Ürün Zaten Favorilerde Kayıtlı.";
                    return response;
                }

                var favorite = new Favorites
                {
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId,
                    CreatedAt = DateTime.Now
                };

                await _context.AddAsync(favorite); // favorilere eklenir
                await _context.SaveChangesAsync(); // değişiklikler kaydedilir

                response.Message = "Ürün Favoriye Eklendi.";
                response.Status = Status.Success;
                response.Result = $"ProductId: {model.ProductId}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/AddFavorite ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<string>> RemoveFavorite(FavoriteRequestDto model)
        {
            Response<string> response = new();
            try
            {
                // gönderilen id'ye ait kullanıcı var mı kontrol eder
                if (!await _context.Customers.AnyAsync(c => c.CustomerId == model.CustomerId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri Bulunamadı.";
                    return response;
                }

                // gönderilen id'ye ait ürün var mı kontrol eder
                if (!await _context.Products.AnyAsync(p => p.ProductId == model.ProductId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Ürün Bulunamadı.";
                    return response;
                }

                var deleted = await _context.Favorites
                    .Where(f => f.CustomerId == model.CustomerId && f.ProductId == model.ProductId)
                    .ExecuteDeleteAsync();

                // silinen kayıt yoksa favori bulunamamıştır
                if (deleted == 0)
                {
                    response.Status = Status.Failed;
                    response.Message = "Ürün Favorilerde Kayıt Değil.";
                    return response;
                }

                response.Status = Status.Success;
                response.Message = "Ürün Favoriden Başarıyla Kaldırıldı.";
                response.Result = $"ProductId: {model.ProductId}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/RemoveFavorite ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<BasicProductResponseDto>>> GetFavorites(int customerId)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                var favoriteProducts = await _productService.GetFavoritesIds(customerId,
                    f => new BasicProductResponseDto
                    {
                        ProductId = f.Product.ProductId,
                        Name = f.Product.Name,
                        Price = f.Product.Price,
                        Score = f.Product.Score,
                        ImagePath = f.Product.ImagePath,
                        IsFavorite = true
                    });

                response.Result = favoriteProducts;
                response.Status = favoriteProducts.Count > 0 ? Status.Success : Status.Failed;
                response.Message = favoriteProducts.Count > 0 ? $"{customerId} Id'li müşterinin favori ürünleri başarıyla getirildi." : $"{customerId} Id'li müşterinin favori ürün bulunamadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/GetFavoriteProducts ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<OrderResponseDto>> GetOrders(int customerId)
        {
            Response<OrderResponseDto> response = new();
            try
            {
                var orders = await _context.OrderHistory
                    .Where(o => o.CustomerId == customerId)
                    .Select(o => new OrderDto
                    {
                        OrderId = o.OrderId,
                        ProductId = o.ProductId,
                        CartId = o.CartId,
                        Status = o.DeliveryDate == null ? OrderStatus.GettingReady : OrderStatus.Delivered,
                        Image = o.Product.ImagePath,
                        OrderDate = o.OrderDate,
                        Price = o.TotalPrice
                    })
                    .ToListAsync();

                response.Result = new OrderResponseDto { CustomerId = customerId, Orders = orders };
                response.Status = orders.Count > 0 ? Status.Success : Status.Failed;
                response.Message = orders.Count > 0 ? $"{customerId} Id'li müşterinin siparişleri başarıyla getirildi." : $"{customerId} Id'li müşterinin siparişi bulunamadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/GetOrders ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }


        // parola formatını güçlendir

        // adresleri getirme metodunu yaz
        public async Task<Response<AddressResponseDto>> GetAddress(int customerId)
        {
            Response<AddressResponseDto> response = new();
            try
            {
                var addresses = await _context.Addresses
                    .Where(a => a.CustomerId == customerId)
                    .Select(a => new AddressDto
                    {
                        AddressId = a.AddressId,
                        AddressName = a.AddressName,
                        Address = a.Address,
                        City = a.City.Name,
                        District = a.District.Name,
                        Neighbourhood = a.Neighbourhood.Name,
                        UpdatedAt = a.UpdatedAt,
                        CreatedAt = a.CreatedAt
                    }).ToListAsync();

                response.Result = new AddressResponseDto { CustomerId = customerId, Addresses = addresses };
                response.Status = addresses.Count > 0 ? Status.Success : Status.Failed;
                response.Message = addresses.Count > 0 ? $"{customerId} Id'li müşterinin adresleri başarıyla getirildi." : $"{customerId} Id'li müşterinin adresi bulunamadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/GetAddress ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<AddressResponseDto>> AddAddress(AddressRequestDto model)
        {
            Response<AddressResponseDto> response = new();
            try
            {
                CheckCustomerDto checkCustomer = new() { CustomerId = model.CustomerId };
                if (!await _authService.CheckExistsCustomer(checkCustomer))
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri Bulunamadı.";
                    return response;
                }

                // girilecek adresin il-ilçe-mahalle bilgileri doğrulanır
                if (model.Address is null || model.Address.City is null || model.Address.District is null || model.Address.Neighbourhood is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Geçersiz adres.";
                    return response;
                }

                if (!await _context.Cities.AnyAsync(c => c.Name == model.Address!.City.Name))
                {
                    response.Status = Status.Failed;
                    response.Message = "Geçersiz şehir.";
                    return response;
                }
                else if (!await _context.Districts.AnyAsync(d => d.Name == model.Address!.District.Name && d.City.Name == model.Address.City.Name))
                {
                    response.Status = Status.Failed;
                    response.Message = "Geçersiz ilçe.";
                    return response;
                }
                else if (!await _context.Neighbourhoods.AnyAsync(n => n.Name == model.Address!.Neighbourhood.Name && n.District.Name == model.Address.District.Name && n.District.City.Name == model.Address.City.Name))
                {
                    response.Status = Status.Failed;
                    response.Message = "Geçersiz mahalle.";
                    return response;
                }

                var receiver = await _context.Customers.FirstOrDefaultAsync(r => r.Name == model.Address.Receiver.Name && r.Surname == model.Address.Receiver.Surname);
                if(receiver is null)
                {
                    await _context.Customers.AddAsync(new Customers
                    {
                        Name = model.Address.Receiver.Name,
                        Surname = model.Address.Receiver.Surname,
                        CreatedAt = DateTime.Now
                    });
                    await _context.SaveChangesAsync();
                }

                var address = new Addresses
                {
                    CustomerId = model.CustomerId,
                    AddressName = model.Address.AddressName,
                    Address = model.Address.Address,
                    CityId = await _context.Cities.Where(c => c.Name == model.Address.City.Name).Select(c => c.CityId).FirstOrDefaultAsync(),
                    DistrictId = await _context.Districts.Where(d => d.Name == model.Address.District.Name && d.City.Name == model.Address.City.Name).Select(d => d.DistrictId).FirstOrDefaultAsync(),
                    NeighbourhoodId = await _context.Neighbourhoods.Where(n => n.Name == model.Address.Neighbourhood.Name && n.District.Name == model.Address.District.Name && n.District.City.Name == model.Address.City.Name  ).Select(n => n.NeighbourhoodId).FirstOrDefaultAsync(),
                    ReceiverId = receiver is not null ? receiver.CustomerId : await _context.Customers.Where(r => r.Name == model.Address.Receiver.Name && r.Surname == model.Address.Receiver.Surname).Select(r => r.CustomerId).FirstOrDefaultAsync(),
                    CreatedAt = DateTime.Now
                };

                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();

                response.Result = new AddressResponseDto 
                { 
                    CustomerId = model.CustomerId, 
                    Addresses = new List<AddressDto> 
                    {
                       new AddressDto{
                           AddressId = address.AddressId,
                           AddressName = address.AddressName,
                           Address = address.Address,
                           City = model.Address.City.Name,
                           District = model.Address.District.Name,
                           Neighbourhood = model.Address.Neighbourhood.Name,
                           CreatedAt = address.CreatedAt,
                           UpdatedAt = address.UpdatedAt
                       }
                    } 
                };
                response.Status = Status.Success;
                response.Message = "Adres başarıyla eklendi.";
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/GetAddress ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<AddressResponseDto>> EditAddress(AddressRequestDto model)
        {
            Response<AddressResponseDto> response = new();
            try
            {
                CheckCustomerDto checkCustomer = new() { CustomerId = model.CustomerId };
                if (!await _authService.CheckExistsCustomer(checkCustomer))
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri Bulunamadı.";
                    return response;
                }

                var address = await _context.Addresses.FirstOrDefaultAsync(a => a.AddressId == model.Address!.AddressId && a.CustomerId == model.CustomerId);

                if (address is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Adres Bulunamadı.";
                    return response;
                }

                if (model is null || model.Address is null || model.Address.City is null || model.Address.District is null || model.Address.Neighbourhood is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Geçersiz adres.";
                    return response;
                }

                address.AddressName = model.Address.AddressName ?? address.AddressName;
                address.Address = model.Address.Address ?? address.Address;
                address.CityId = model.Address.City is not null ? await _context.Cities.Where(c => c.Name == model.Address.City.Name).Select(c => c.CityId).FirstOrDefaultAsync() : address.CityId;
                address.DistrictId = model.Address.District is not null ? await _context.Districts.Where(d => d.Name == model.Address.District.Name && d.City.Name == model.Address.City!.Name).Select(d => d.DistrictId).FirstOrDefaultAsync() : address.DistrictId;
                address.NeighbourhoodId = model.Address.Neighbourhood is not null ? await _context.Neighbourhoods.Where(n => n.Name == model.Address.Neighbourhood.Name && n.District.Name == model.Address.District!.Name && n.District.City.Name == model.Address.City!.Name).Select(n => n.NeighbourhoodId).FirstOrDefaultAsync() : address.NeighbourhoodId;
                address.UpdatedAt = DateTime.Now;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CustomerService/GetAddress ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        // adres ekleme, silme, güncelleme metodlarını yaz


    }
}
