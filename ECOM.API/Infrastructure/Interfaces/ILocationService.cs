using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Location;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface ILocationService
    {
        public Task<Response<List<CityDto>>> GetCities();
        public Task<Response<List<DistrictDto>>> GetDistricts(int cityId);
        public Task<Response<List<NeighbourhoodDto>>> GetNeighbourhoods(int districtId);
    }
}
