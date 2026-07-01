using ECOM.Shared.Data.DTOs.Location;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface ILocationService
    {
        public Task<List<CityDto>> GetCities();
        public Task<List<DistrictDto>> GetDistricts(int cityId);
        public Task<List<NeighbourhoodDto>> GetNeighbourhoods(int districtId);
    }
}
