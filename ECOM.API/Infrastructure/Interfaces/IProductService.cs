using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IProductService
    {
        public Task<Response<List<BasicProductResponseDto>>> GetProducts(int? customerId);
        public Task<Response<DetailProductResponseDto>> GetProductDetails(DetailProductRequestDto model);
        public Task<Response<List<BasicProductResponseDto>>> GetFavoriteProducts(int customerId);
    }
}
