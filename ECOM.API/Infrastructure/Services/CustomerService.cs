using ECOM.API.Data;
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

        public Task<Response<BasicCustomerResponseDto>> ChangeBasicInfo(BasicCustomerRequestDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ContactInfoResponseDto>> ChangeContactInfo(ContactInfoRequestDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> ChangePassword(ChangePasswordRequestDto model)
        {
            Response<int> response = new();
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/ChangePassword ==> Error: {ex}");
            }
            return Task.FromResult(response);
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
                _logger.LogError($"ProductService/AddFavorite ==> Error: {ex}");
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
                _logger.LogError($"ProductService/RemoveFavorite ==> Error: {ex}");
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
                _logger.LogError($"ProductService/GetFavoriteProducts ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
