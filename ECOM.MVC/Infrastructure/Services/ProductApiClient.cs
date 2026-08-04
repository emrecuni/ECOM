using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using Newtonsoft.Json;
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

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<string>>(ct);
                return ApiResult<Response<string>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<string>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<string>>?> AddCommentAsync(AddCommentRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product/AddComment", model, ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<string>>(ct);
                return ApiResult<Response<string>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<string>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<string>>?> EditCartAsync(EditCartRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Product/EditCart", model, ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<string>>(ct);
                return ApiResult<Response<string>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<string>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>?> GetAllProductsAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetAllProducts?customerId={customerId}", ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<List<BasicProductResponseDto>>>(ct);
                return ApiResult<Response<List<BasicProductResponseDto>>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<List<BasicProductResponseDto>>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<List<CartResponseDto>>>?> GetCartAsync(int customerId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetCart?customerId={customerId}", ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<List<CartResponseDto>>>(ct);
                return ApiResult<Response<List<CartResponseDto>>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<List<CartResponseDto>>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<DetailProductResponseDto>>?> GetProductDetailsAsync(DetailProductRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetProductDetails?productId={model.ProductId}&customerId={model.CustomerId}", ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<DetailProductResponseDto>>(ct);
                return ApiResult<Response<DetailProductResponseDto>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<DetailProductResponseDto>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>> SearchProductsByWithCategory(SearchProductByCategoryRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/SearchProductsByWithCategory?categoryId={model.CategoryId}&customerId={model.CustomerId}", ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<List<BasicProductResponseDto>>>(ct);
                return ApiResult<Response<List<BasicProductResponseDto>>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<List<BasicProductResponseDto>>>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<List<BasicProductResponseDto>>>> SearchProductsByWithName(SearchProductByNameRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Product/SearchProductsByWithName?name={model.ProductName}&customerId={model.CustomerId}", ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<List<BasicProductResponseDto>>>(ct);
                return ApiResult<Response<List<BasicProductResponseDto>>>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<List<BasicProductResponseDto>>>.Fail(error, response.StatusCode);
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
