using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Location;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface ILocationApiClient
    {
        public Task<ApiResult<Response<List<CityDto>>>> GetCitiesAsync(CancellationToken ct);
        public Task<ApiResult<Response<List<DistrictDto>>>> GetDistrictsAsync(int cityId, CancellationToken ct);
        public Task<ApiResult<Response<List<NeighbourhoodDto>>>> GetNeighbourhoodsAsync(int districtId, CancellationToken ct);
    }
}
