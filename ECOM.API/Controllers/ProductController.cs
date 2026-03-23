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
        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts([FromQuery] int? customerId)
        {
            var response = await _productService.GetProducts(customerId);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("getproductdetails")]
        public async Task<IActionResult> GetProductDetails(int productId, int? customerId)
        {
            var response = await _productService.GetProductDetails(productId,customerId);
            return Ok(response);
        }

        [HttpGet("getfavoriteproducts")]
        public async Task<IActionResult> GetFavoriteProducts(int customerId)
        {
            var response = await _productService.GetFavoriteProducts(customerId);
            return Ok(response);
        }
    }
}