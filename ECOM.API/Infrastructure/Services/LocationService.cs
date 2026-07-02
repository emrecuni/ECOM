using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ECOM.API.Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _context;
        private readonly IMemoryCache _cache;

        public LocationService(DataContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<CityDto>> GetCities()
        {
            if (_cache.TryGetValue("cities", out List<CityDto>? cached))
                return cached is null ? cached = new List<CityDto>() : cached;

            var cities = await _context.Cities
                .Select(c => new CityDto
                {
                    CityId = c.CityId,
                    Name = c.Name
                })
                .ToListAsync();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(24)) // 24 saat sonra kesin sil
                .SetSlidingExpiration(TimeSpan.FromHours(1)); // 1 saat kullanılmazsa sil

            _cache.Set("cities", cities, options);
            return cities;
        }

        public async Task<List<DistrictDto>> GetDistricts(int cityId)
        {
            if (_cache.TryGetValue("districts", out List<DistrictDto>? cached))
                return cached is null ? cached = new List<DistrictDto>() : cached;

            var districts = await _context.Districts
                .Select(d => new DistrictDto
                {
                    DistrictId = d.DistrictId,
                    Name = d.Name
                })
                .ToListAsync();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(24))
                .SetSlidingExpiration(TimeSpan.FromHours(1));

            _cache.Set("districts", districts, options);
            return districts;
        }
        public async Task<List<NeighbourhoodDto>> GetNeighbourhoods(int districtId)
        {
            if(_cache.TryGetValue("neighbourhoods", out List<NeighbourhoodDto>? cached))
                return cached is null ? cached = new List<NeighbourhoodDto>() : cached;

            var neighbourhoods = await _context.Neighbourhoods
                .Select(n => new NeighbourhoodDto
                {
                    NeighbourhoodId = n.NeighbourhoodId,
                    Name = n.Name
                })
                .ToListAsync();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration (TimeSpan.FromHours(24))
                .SetSlidingExpiration(TimeSpan.FromHours(1));

            _cache.Set("neighbourhoods", neighbourhoods, options);
            return neighbourhoods;
        }
    }
}
