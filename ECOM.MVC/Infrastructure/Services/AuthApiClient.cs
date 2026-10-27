using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Smtp;
using System.Text.Json;
using System.Net;

namespace ECOM.MVC.Infrastructure.Services
{
    public class AuthApiClient : IAuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<LoginResponseDto>?> TokenAsync(LoginRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Token", model, ct);
            return await ToApiResultAsync<LoginResponseDto>(response, ct);
        }

        public async Task<ApiResult<Response<SmtpResponseDto>?>> SendOtpAsync(OtpRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/SendOTP", model, ct);
            return await ToApiResultAsync<Response<SmtpResponseDto>?>(response, ct);
        }

        public async Task<ApiResult<Response<OtpResponseDto>?>> CheckOtpAsync(OtpRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/CheckOTP", model, ct);
            return await ToApiResultAsync<Response<OtpResponseDto>?>(response, ct);
        }

        public async Task<ApiResult<Response<RegisterResponseDto>?>> RegisterAsync(RegisterRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", model, ct);
            return await ToApiResultAsync<Response<RegisterResponseDto>?>(response, ct);
        }

        public async Task<ApiResult<Response<ResetPasswordResponseDto>?>> ResetPasswordAsync(ResetPasswordRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/ResetPassword", model, ct);
            return await ToApiResultAsync<Response<ResetPasswordResponseDto>?>(response, ct);
        }

        public async Task<ApiResult<Response<bool>>> CheckExistsCustomer(CheckCustomerDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/CheckExistsCustomer", model, ct);
            return await ToApiResultAsync<Response<bool>>(response, ct);
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
