using ECOM.API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
