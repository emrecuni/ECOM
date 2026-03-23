using ECOM.API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("getproducts")]
        public async Task<IActionResult> GetProducts([FromQuery] int? customerId)
        {
            var response = await _productService.GetProducts(customerId);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("getproductsdetails")]
        public async Task<IActionResult> GetProductDetails(int productId)
        {
            var response = await _productService.GetProductDetails(productId);
            return Ok(response);
        }

        [HttpPost("getfavoriteproducts")]
        public async Task<IActionResult> GetFavoriteProducts(int customerId)
        {
            var response = await _productService.GetFavoriteProducts(customerId);
            return Ok(response);
        }
    }
}