using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationService locationService, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            var result = await _locationService.GetCities();

            if(result.Status == Status.Error)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetDistricts")]
        public async Task<IActionResult> GetDistricts([FromQuery] int cityId)
        {
            var result = await _locationService.GetDistricts(cityId);

            if (result.Status == Status.Error)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetNeighbourhoods")]
        public async Task<IActionResult> GetNeighbourhoods([FromQuery] int districtId)
        {
            var result = await _locationService.GetNeighbourhoods(districtId);

            if (result.Status == Status.Error)
                return BadRequest(result);

            return Ok(result);
        }
    }
}