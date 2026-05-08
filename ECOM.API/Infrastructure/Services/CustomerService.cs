using ECOM.API.Data;
using ECOM.API.Helpers;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IProductService _productService;
        private readonly DataContext _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IProductService productService,DataContext context, ILogger<CustomerService> logger)
        {
            _productService = productService;
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
                    .FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId)
                    ;
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

        public Task<Response<ContactInfoResponseDto>> ChangeContactInfo(ContactInfoRequestDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> ChangePassword(ChangePasswordRequestDto model)
        {
            Response<int> response = new();
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId);
                if(customer is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri bulunamadı.";
                    return response;
                }
                else if (EncryptionHelper.VerifyPassword(model.OldPassword, customer.Password!))
                {
                    if(model.NewPassword == model.ReNewPassword)
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
                response.Message= ex.Message;
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
    }
}
