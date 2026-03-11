using ECOM.API.Data;
using ECOM.Shared.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(DataContext context,ILogger<CustomerController> logger) 
        {
            _context = context;
            _logger = logger;
        }

        
    }
}
