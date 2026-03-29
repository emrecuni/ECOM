using System.Linq.Expressions;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Entities;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IProductService
    {
        public Task<Response<List<BasicProductResponseDto>>> GetProducts(int customerId);
        public Task<Response<DetailProductResponseDto>> GetProductDetails(DetailProductRequestDto model);  
        public Task<Response<string>> AddCart(AddCartRequestDto model);
        public Task<Response<string>> EditCart(EditCartRequestDto model);
        public Task<Response<CartResponseDto>> GetCart(int customerId);      
        public Task<Response<string>> AddComment(AddCommentRequestDto model);
        public Task<Response<List<BasicProductResponseDto>>> SearchProductsByWithName(SearchProductByNameRequestDto model);
        public Task<Response<List<BasicProductResponseDto>>> SearchProductsByWithCategory(SearchProductByCategoryRequestDto model);
        public Task<List<TResult>> GetFavoritesIds<TResult>(int customerId, Expression<Func<Favorites, TResult>> selector);
    }
}