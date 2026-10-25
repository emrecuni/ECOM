using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Product;
using Newtonsoft.Json;
using System.Net;

namespace ECOM.MVC.Infrastructure.Services
{
    public class CustomerApiClient : ICustomerApiClient
    {
        private readonly HttpClient _httpClient;

        public CustomerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Favorites
        public async Task<ApiResult<Response<string>>> AddFavoriteAsync(FavoriteRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Customer/AddFavorite", model, ct);
            return await ToApiResultAsync<Response<string>>(response, ct);
        }

        public async Task<ApiResult<Response<string>>> RemoveFavoriteAsync(FavoriteRequestDto model, CancellationToken ct)
        {
            var response = await DeleteAsJsonAsync("api/Customer/RemoveFavorite", model, ct);
            return await ToApiResultAsync<Response<string>>(response, ct);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>> GetFavoritesAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Customer/GetFavorites?customerId={customerId}", ct);
            return await ToApiResultAsync<Response<List<BasicProductResponseDto>>>(response, ct);
        }
        #endregion Favorites

        public async Task<ApiResult<Response<GetCouponsResponseDto>>> GetCouponsAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Customer/GetCoupons?customerId={customerId}", ct);
            return await ToApiResultAsync<Response<GetCouponsResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<int>>> ChangePasswordAsync(ChangePasswordRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Customer/ChangePassword", model, ct);
            return await ToApiResultAsync<Response<int>>(response, ct);
        }

        public async Task<ApiResult<Response<BasicCustomerResponseDto>>> ChangeBasicInfoAsync(BasicCustomerRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Customer/ChangeBasicInfo", model, ct);
            return await ToApiResultAsync<Response<BasicCustomerResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<ContactInfoResponseDto>>> ChangeContactInfoAsync(ContactInfoRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Customer/ChangeContactInfo", model, ct);
            return await ToApiResultAsync<Response<ContactInfoResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<OrderResponseDto>>> GetOrdersAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Customer/GetOrders?customerId={customerId}", ct);
            return await ToApiResultAsync<Response<OrderResponseDto>>(response, ct);
        }

        #region Address
        public async Task<ApiResult<Response<AddressResponseDto>>> GetAddressAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Customer/GetAddress?customerId={customerId}", ct);
            return await ToApiResultAsync<Response<AddressResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<AddressResponseDto>>> AddAddressAsync(AddressRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Customer/AddAddress", model, ct);
            return await ToApiResultAsync<Response<AddressResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<AddressResponseDto>>> EditAddressAsync(AddressRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Customer/EditAddress", model, ct);
            return await ToApiResultAsync<Response<AddressResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<string>>> RemoveAddressAsync(AddressRequestDto model, CancellationToken ct)
        {
            var response = await DeleteAsJsonAsync("api/Customer/RemoveAddress", model, ct);
            return await ToApiResultAsync<Response<string>>(response, ct);
        }
        #endregion Address

        // API'deki DELETE uçları [FromBody] beklediği için body'li DELETE isteği gönderilir
        private Task<HttpResponseMessage> DeleteAsJsonAsync<T>(string url, T model, CancellationToken ct)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = JsonContent.Create(model)
            };

            return _httpClient.SendAsync(request, ct);
        }

        private static async Task<ApiResult<T>> ToApiResultAsync<T>(HttpResponseMessage response, CancellationToken ct)
        {
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<T>(ct);
                return ApiResult<T>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<T>.Fail(error, response.StatusCode);
        }

        private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response, CancellationToken ct)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<ApiErrorResponse>(ct);
                if (!string.IsNullOrWhiteSpace(body?.Message))
                    return body.Message;
            }
            catch (JsonException)
            {
                // body JSON değilse ya da beklenen formatta değilse yut, genel mesaja düş
            }

            return response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => "Oturum bilgileriniz geçersiz.",
                HttpStatusCode.NotFound => "Kayıt bulunamadı.",
                HttpStatusCode.BadRequest => "Geçersiz istek.",
                _ => "Bir hata oluştu, lütfen tekrar deneyin."
            };
        }
    }
}
