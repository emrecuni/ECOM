using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Location;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
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

        public async Task<Response<List<CityDto>>> GetCities()
        {
            Response<List<CityDto>> response = new();
            response.Status = Status.Default;
            try
            {
                if (_cache.TryGetValue("cities", out List<CityDto>? cached))
                {
                    if (cached is not null && cached.Count > 0)
                    {
                        response.Status = Status.Success;
                        response.Result = cached;
                        response.Message = "Şehirler önbellekten getirildi.";
                        return response;
                    }
                }

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
                response.Status = Status.Success;
                response.Result = cities;
                response.Message = "Şehirler getirildi.";
            }
            catch (Exception ex)
            {
                response.Status = Status.Error;
                response.Message = $"Şehirler getirilirken bir hata oluştu: {ex.Message}";
            }
            
            return response;
        }

        public async Task<Response<List<DistrictDto>>> GetDistricts(int cityId)
        {
            Response<List<DistrictDto>> response = new();
            response.Status = Status.Default;

            try
            {
                if (_cache.TryGetValue($"districts_{cityId}", out List<DistrictDto>? cached))
                {
                    if (cached is not null && cached.Count > 0)
                    {
                        response.Status = Status.Success;
                        response.Result = cached;
                        response.Message = "İlçeler önbellekten getirildi.";
                        return response;
                    }
                }

                var districts = await _context.Districts
                    .Where(d => d.CityId == cityId)
                    .Select(d => new DistrictDto
                    {
                        DistrictId = d.DistrictId,
                        Name = d.Name
                    })
                    .ToListAsync();

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24))
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

                _cache.Set($"districts_{cityId}", districts, options);
                response.Status = Status.Success;
                response.Result = districts;
                response.Message = "İlçeler getirildi.";
            }
            catch (Exception ex)
            {
                response.Status = Status.Error;
                response.Message = $"İlçeler getirilirken bir hata oluştu: {ex.Message}";
            }
          
            return response;
        }

        public async Task<Response<List<NeighbourhoodDto>>> GetNeighbourhoods(int districtId)
        {
            Response<List<NeighbourhoodDto>> response = new();
            response.Status = Status.Default;

            try
            {
                if (_cache.TryGetValue($"neighbourhoods_{districtId}", out List<NeighbourhoodDto>? cached))
                {
                    if (cached is not null && cached.Count > 0)
                    {
                        response.Status = Status.Success;
                        response.Result = cached;
                        response.Message = "Mahalleler önbellekten getirildi.";
                        return response;
                    }
                }

                var neighbourhoods = await _context.Neighbourhoods
                    .Where(n => n.DistrictId == districtId)
                    .Select(n => new NeighbourhoodDto
                    {
                        NeighbourhoodId = n.NeighbourhoodId,
                        Name = n.Name
                    })
                    .ToListAsync();

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24))
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

                _cache.Set($"neighbourhoods_{districtId}", neighbourhoods, options);
                response.Status = Status.Success;
                response.Result = neighbourhoods;
                response.Message = "Mahalleler getirildi.";
            }
            catch (Exception ex)
            {
                response.Status = Status.Error;
                response.Message = $"Mahalleler getirilirken bir hata oluştu: {ex.Message}";
            }

            return response;
        }
    }
}
