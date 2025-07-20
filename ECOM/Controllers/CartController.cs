using ECOM.Data;
using ECOM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır

            var carts = await _context.Carts
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .Include(c => c.Seller)
                .Include(c => c.Coupon)
                .Where(c => c.CustomerId == customerId && c.Enable == true)
                .ToListAsync();

            return View(carts);
        }
    }
}
