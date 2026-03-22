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

        public Task<Response<BasicProductDto>> GetFavoriteProducts(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<DetailProductDto>> GetProductDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<BasicProductDto>>> GetProducts(int customerId)
        {
            Response<List<BasicProductDto>> response = new();
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

                response.Result = [.. products.Select(p => new BasicProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Score = p.Score,
                    ImagePath = p.ImagePath,
                    IsFavorite = favorites.Contains(p.ProductId) // ürün favoriler arasında mı kontrolü
                })];

                response.Status = Status.Success;
                response.Message = response.Result.Count > 0 ? "Ürünler başarıyla getirildi." : "Ürün bulunmadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetProducts => Error: {ex} ");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
