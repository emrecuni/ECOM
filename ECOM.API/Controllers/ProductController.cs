using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs.Product;
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
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] int customerId)
        {
            var response = await _productService.GetProducts(customerId);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetProductDetails")]
        public async Task<IActionResult> GetProductDetails([FromQuery] DetailProductRequestDto model)
        {
            if (model is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _productService.GetProductDetails(model);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart([FromQuery] int customerId)
        {
            var response = await _productService.GetCart(customerId);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("AddCart")]
        public async Task<IActionResult> AddCart([FromBody] AddCartRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _productService.AddCart(model);
            return Ok(response);
        }

        [Authorize]
        [HttpPatch("EditCart")]
        public async Task<IActionResult> EditCart([FromBody] EditCartRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _productService.EditCart(model);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(AddCommentRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _productService.AddComment(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("SearchProductsByWithName")]
        public async Task<IActionResult> SearchProductsByWithName([FromBody] SearchProductByNameRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _productService.SearchProductsByWithName(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("SearchProductsByWithCategory")]
        public async Task<IActionResult> SearchProductsByWithCategory([FromBody] SearchProductByCategoryRequestDto model)
        {
            if (!ModelState.IsValid || model is null)
                return BadRequest(ModelState);

            var response = await _productService.SearchProductsByWithCategory(model);
            return Ok(response);
        }
    }
}