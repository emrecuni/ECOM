using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.DTOs.Customer;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        public Task<Response<BasicCustomerResponseDto>> ChangeBasicInfo(BasicCustomerRequestDto model);
        public Task<Response<ContactInfoResponseDto>> ChangeContactInfo(ContactInfoRequestDto model);
        public Task<Response<int>> ChangePassword(ChangePasswordRequestDto model);
        public Task<Response<GetCouponsResponseDto>> GetCoupons(int customerId);
        public Task<Response<string>> AddFavorite(FavoriteRequestDto model);
        public Task<Response<string>> RemoveFavorite(FavoriteRequestDto model);
        public Task<Response<List<BasicProductResponseDto>>> GetFavorites(int customerId);
        public Task<Response<OrderResponseDto>> GetOrders(int customerId);
        public Task<Response<AddressResponseDto>> GetAddress(int customerId);
    }
}
