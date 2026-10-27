using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using System.Text.Json;
using System.Net;

namespace ECOM.MVC.Infrastructure.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<Response<string>>?> AddCartAsync(AddCartRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product/AddCart", model, ct);
            return await ToApiResultAsync<Response<string>>(response, ct);
        }

        public async Task<ApiResult<Response<string>>?> AddCommentAsync(AddCommentRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product/AddComment", model, ct);
            return await ToApiResultAsync<Response<string>>(response, ct);
        }

        public async Task<ApiResult<Response<string>>?> EditCartAsync(EditCartRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Product/EditCart", model, ct);
            return await ToApiResultAsync<Response<string>>(response, ct);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>?> GetAllProductsAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetProducts?customerId={customerId}", ct);
            return await ToApiResultAsync<Response<List<BasicProductResponseDto>>>(response, ct);
        }

        public async Task<ApiResult<Response<CartResponseDto>>?> GetCartAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetCart?customerId={customerId}", ct);
            return await ToApiResultAsync<Response<CartResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<DetailProductResponseDto>>?> GetProductDetailsAsync(DetailProductRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetProductDetails?productId={model.ProductId}&customerId={model.CustomerId}", ct);
            return await ToApiResultAsync<Response<DetailProductResponseDto>>(response, ct);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>> SearchProductsByWithCategory(SearchProductByCategoryRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Product/SearchProductsByWithCategory", model, ct);
            return await ToApiResultAsync<Response<List<BasicProductResponseDto>>>(response, ct);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>> SearchProductsByWithName(SearchProductByNameRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/SearchProductsByWithName?name={model.ProductName}&customerId={model.CustomerId}", ct);
            return await ToApiResultAsync<Response<List<BasicProductResponseDto>>>(response, ct);
        }

        public async Task<ApiResult<Response<List<int>>>> GetCategoryIdsAsync(string category, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetCategoryIds?category={category}", ct);
            return await ToApiResultAsync<Response<List<int>>>(response, ct);
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
                // JWT doğrulamasının döndüğü 401 gibi yanıtlarda gövde boş gelir; boş gövde json olarak okunmaya çalışılmaz
                var content = await response.Content.ReadAsStringAsync(ct);
                if (!string.IsNullOrWhiteSpace(content))
                {
                    var body = JsonSerializer.Deserialize<ApiErrorResponse>(content, JsonSerializerOptions.Web);
                    if (!string.IsNullOrWhiteSpace(body?.Message))
                        return body.Message;
                }
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
