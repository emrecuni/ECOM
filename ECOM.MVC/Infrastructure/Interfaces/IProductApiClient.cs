using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface IProductApiClient
    {
        public Task<ApiResult<Response<PagedProductResponseDto>>?> GetAllProductsAsync(int customerId, int? lastId, CancellationToken ct);
        public Task<ApiResult<Response<DetailProductResponseDto>>?> GetProductDetailsAsync(DetailProductRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<CartResponseDto>>?> GetCartAsync(int customerId, CancellationToken ct);
        public Task<ApiResult<Response<string>>?> AddCartAsync(AddCartRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<string>>?> EditCartAsync(EditCartRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<string>>?> AddCommentAsync(AddCommentRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<List<BasicProductResponseDto>>>> SearchProductsByWithNameAsync(SearchProductByNameRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<List<BasicProductResponseDto>>>> SearchProductsByWithCategoryAsync(SearchProductByCategoryRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<List<int>>>> GetCategoryIdsAsync(string category, CancellationToken ct);
        public Task<ApiResult<Response<List<CategoryMenuDto>>>> GetCategoryMenuAsync(CancellationToken ct);
    }
}
