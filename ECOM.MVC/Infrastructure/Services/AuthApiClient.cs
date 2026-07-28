using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Smtp;
using Newtonsoft.Json;
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

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<LoginResponseDto>(ct);
                return ApiResult<LoginResponseDto>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<LoginResponseDto>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<SmtpResponseDto>?>> SendOtpAsync(OtpRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/SendOTP", model, ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<SmtpResponseDto>>(ct);
                return ApiResult<Response<SmtpResponseDto>?>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<SmtpResponseDto>?>.Fail(error, response.StatusCode);
        }

        public async Task<ApiResult<Response<OtpResponseDto>?>> CheckOtpAsync(OtpRequestDto model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/CheckOTP", model, ct);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Response<OtpResponseDto>>(ct);
                return ApiResult<Response<OtpResponseDto>?>.Ok(data!, response.StatusCode);
            }

            var error = await ReadErrorMessageAsync(response, ct);
            return ApiResult<Response<OtpResponseDto>?>.Fail(error, response.StatusCode);
        }

        public Task<ApiResult<Response<RegisterResponseDto>?>> RegisterAsync(RegisterRequestDto model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<Response<ResetPasswordResponseDto>?>> ResetPassword(ResetPasswordRequestDto model, CancellationToken ct)
        {
            throw new NotImplementedException();
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
