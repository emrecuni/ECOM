using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Location;
using Newtonsoft.Json;
using System.Net;

namespace ECOM.MVC.Infrastructure.Services
{
    public class LocationApiClient : ILocationApiClient
    {
        private readonly HttpClient _httpClient;

        public LocationApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<Response<List<CityDto>>>> GetCitiesAsync(CancellationToken ct)
        {
            var response = await _httpClient.GetAsync("api/Location/GetCities", ct);
            return await ToApiResultAsync<Response<List<CityDto>>>(response, ct);
        }

        public async Task<ApiResult<Response<List<DistrictDto>>>> GetDistrictsAsync(int cityId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Location/GetDistricts?cityId={cityId}", ct);
            return await ToApiResultAsync<Response<List<DistrictDto>>>(response, ct);
        }

        public async Task<ApiResult<Response<List<NeighbourhoodDto>>>> GetNeighbourhoodsAsync(int districtId, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync($"api/Location/GetNeighbourhoods?districtId={districtId}", ct);
            return await ToApiResultAsync<Response<List<NeighbourhoodDto>>>(response, ct);
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
