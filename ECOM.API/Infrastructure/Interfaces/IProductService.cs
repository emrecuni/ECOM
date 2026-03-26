using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IProductService
    {
        public Task<Response<List<BasicProductResponseDto>>> GetProducts(int? customerId);
        public Task<Response<DetailProductResponseDto>> GetProductDetails(DetailProductRequestDto model);
        public Task<Response<List<BasicProductResponseDto>>> GetFavoriteProducts(int customerId);
        public Task<Response<string>> AddCart(AddCartRequestDto model);
        public Task<Response<string>> EditCart(EditCartRequestDto model);
        public Task<Response<CartResponseDto>> GetCart(int customerId);
        public Task<Response<string>> AddFavorite(AddFavoriteRequestDto model);
    }
}