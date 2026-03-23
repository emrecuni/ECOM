using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(DataContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Response<List<BasicProductResponseDto>>> GetFavoriteProducts(int customerId)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                var favoriteProducts = await _context.Favorites
                    .Where(f => f.CustomerId == customerId)
                    .Select(f => new BasicProductResponseDto
                    {
                        ProductId = f.Product.ProductId,
                        Name = f.Product.Name,
                        Price = f.Product.Price,
                        Score = f.Product.Score,
                        ImagePath = f.Product.ImagePath,
                        IsFavorite = true
                    })
                    .ToListAsync();

                response.Result = favoriteProducts;
                response.Status = favoriteProducts.Count > 0 ? Status.Success : Status.Failed;
                response.Message = favoriteProducts.Count > 0 ? "Favori ürünler başarıyla getirildi." : "Favori ürün bulunamadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetFavoriteProducts ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DetailProductResponseDto>> GetProductDetails(DetailProductRequestDto model)
        {
            Response<DetailProductResponseDto> response = new();
            try
            {
                var product = await _context.Products
                    .Where(p => p.ProductId == model.ProductId)
                    .Select(p => new DetailProductResponseDto
                    {
                        ProductId = p.ProductId,
                        BrandId = p.BrandId,
                        BrandName = p.Brand.Name,
                        SupCategoryId = p.SupCategoryId,
                        SupCategory = p.SupCategory.Name,
                        SubCategoryId = p.SubCategoryId,
                        SubCategory = p.SubCategory.Name,
                        SellerId = p.SellerId,
                        SellerName = p.Seller.Name,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Score = p.Score,
                        ImagePath = p.ImagePath,
                        Comments = p.Comments.Select(c => new CommentsDto
                        {
                            CommentId = c.CommentId,
                            CustomerName = c.Customer.Name,
                            CustomerSurname = c.Customer.Surname,
                            Score = c.Score,
                            ImagePath = c.ImagePath,
                            Comment = c.Comment
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (product is not null && model.CustomerId.HasValue)
                    product.IsFavorite = await _context.Favorites.AnyAsync(f => f.CustomerId == model.CustomerId && f.ProductId == model.ProductId); // favori kontrolü

                response.Status = product is not null ? Status.Success : Status.Failed;
                response.Message = product is not null ? "Ürün başarıyla getirildi." : "Ürün bulunamadı.";
                response.Result = product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetProductDetails ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<BasicProductResponseDto>>> GetProducts(int? customerId)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                // db'den 20 ürün çeker
                var products = await _context.Products
                    .Take(20)
                    .Select(p => new { p.ProductId, p.Name, p.Price, p.Score, p.ImagePath })
                    .ToListAsync();

                // db'den kullanıcın favorilere attığı ürünlerin id'lerini çeker
                var favorites = await _context.Favorites
                    .Where(f => f.CustomerId == customerId)
                    .Select(f => f.ProductId)
                    .ToListAsync();

                response.Result = [.. products.Select(p => new BasicProductResponseDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Score = p.Score,
                    ImagePath = p.ImagePath,
                    IsFavorite = favorites.Contains(p.ProductId) // ürün favoriler arasında mı kontrolü
                })];

                response.Status = response.Result.Count > 0 ? Status.Success : Status.Failed;
                response.Message = response.Result.Count > 0 ? "Ürünler başarıyla getirildi." : "Ürün bulunmadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetProducts ==> Error: {ex} ");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
