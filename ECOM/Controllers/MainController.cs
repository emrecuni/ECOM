using ECOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class MainController : Controller
    {
        private readonly DataContext _context;

        public MainController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            // veri tabanındaki bütün ürünleri çeker
            var products = await _context.Products
                .Include(b => b.Brand)
                .Include(c => c.SupCategory)
                .Include(c => c.SubCategory)
                .Include(s => s.Seller)
                .ToListAsync();

            return View(products);
        }
    }
}
