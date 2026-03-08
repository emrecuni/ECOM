using ECOM_API.Data;
using ECOM_API.Data.Entity;
using ECOM_API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM_API.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<LoginController> _logger;

        public LoginController(DataContext context, ILogger<LoginController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> ValidateUser(LoginViewModel model)
        {
            try
            {
                if(model is null)
                    return NoContent();

                Customers customer = await _context.Customers.FirstAsync(c => c.Email == model.Email || c.Phone == model.Email);



                return Ok();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}
