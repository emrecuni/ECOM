using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface ICustomerApiClient
    {
        public Task<ApiResult<Response<BasicCustomerResponseDto>>> GetCustomerByIdAsync(int customerId, CancellationToken ct);
        public Task<ApiResult<Response<string>>> AddFavoriteAsync(FavoriteRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<string>>> RemoveFavoriteAsync(FavoriteRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<List<BasicProductResponseDto>>>> GetFavoritesAsync(int customerId, CancellationToken ct);
        public Task<ApiResult<Response<GetCouponsResponseDto>>> GetCouponsAsync(int customerId, CancellationToken ct);
        public Task<ApiResult<Response<int>>> ChangePasswordAsync(ChangePasswordRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<BasicCustomerResponseDto>>> ChangeBasicInfoAsync(BasicCustomerRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<ContactInfoResponseDto>>> ChangeContactInfoAsync(ContactInfoRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<OrderResponseDto>>> GetOrdersAsync(int customerId, CancellationToken ct);
        public Task<ApiResult<Response<AddressResponseDto>>> GetAddressAsync(int customerId, CancellationToken ct);
        public Task<ApiResult<Response<AddressResponseDto>>> AddAddressAsync(AddressRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<AddressResponseDto>>> EditAddressAsync(AddressRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<string>>> RemoveAddressAsync(AddressRequestDto model, CancellationToken ct);
    }
}
