using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IProductService
    {
        public Task<Response<List<BasicProductDto>>> GetProducts(int customerId);
        public Task<Response<DetailProductDto>> GetProductDetails(int productId);
        public Task<Response<BasicProductDto>> GetFavoriteProducts(int customerId);
    }
}
