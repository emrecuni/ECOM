using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.API.Infrastructure.Services;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("AddFavorite")]
        public async Task<IActionResult> AddFavorite([FromBody] FavoriteRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _customerService.AddFavorite(model);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("RemoveFavorite")]
        public async Task<IActionResult> RemoveFavorite([FromBody] FavoriteRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _customerService.RemoveFavorite(model);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetFavorites")]
        public async Task<IActionResult> GetFavorites([FromQuery] int customerId)
        {
            var response = await _customerService.GetFavorites(customerId);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetCoupons")]
        public async Task<IActionResult> GetCoupons([FromQuery] int customerId)
        {
            var response = await _customerService.GetCoupons(customerId);
            return Ok(response);
        }

        [Authorize]
        [HttpPatch("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto model)
        {
            var response = await _customerService.ChangePassword(model);
            return Ok(response);
        }

        [Authorize]
        [HttpPatch("ChangeBasicInfo")] 
        public async Task<IActionResult> ChangeBasicInfo([FromBody] BasicCustomerRequestDto model)
        {
            var response = await _customerService.ChangeBasicInfo(model);
            return Ok(response);
        }

        [Authorize]
        [HttpPatch("ChangeContactInfo")]
        public async Task<IActionResult> ChangeContactInfo([FromBody] ContactInfoRequestDto model)
        {
            var response = await _customerService.ChangeContactInfo(model);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders([FromQuery] int customerId)
        {
            var response = await _customerService.GetOrders(customerId);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAddress")]
        public async Task<IActionResult> GetAddress([FromQuery] int customerId)
        {
            var response = await _customerService.GetAddress(customerId);
            return Ok(response);
        }
    } 
}