using ECOM.Data;
using ECOM.Services;
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
            /*
             * bütün verileri çekme
             * null kontrolü ekle
             * exception kontrolü ekle
             */

            // veri tabanındaki bütün ürünleri çeker
            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.SupCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.Seller)                
                .ToListAsync();

            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> ProductsByCategoryName(string category)
        {
            try
            {
                var products = await _context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.SupCategory)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Seller)
                    .Where(p => p.SupCategory.Name == category.ToUpper())
                    .ToListAsync();

                return View("Index", products);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"ProductsByCategoryName Error => {ex}");
                return View();
            }
        }

        public async Task<IActionResult> ProductsByCategoryId(int id)
        {
            try
            {
                if (id == 0) // buradaki kontrolü geliştir
                    return View("Index");

                var products = await _context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.SupCategory)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Seller)
                    .Where(p => p.SupCategoryId == id || p.SubCategoryId == id)
                    .ToListAsync();

                return View("Index", products);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"ProductsByCategoryId Error => {ex}");
                return View("Index");
            }
        }

        public async Task<IActionResult> SearchProductByName(string search)
        {
            try
            {
                if (search is null)
                    return View("Index");

                var products = await _context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.SupCategory)
                    .Include(p => p.SubCategory)
                    .Include(p => p.Seller)
                    .Where(p => p.Name!.ToUpper().Contains(search.ToUpper())
                    || p.Seller.Name!.ToUpper().Contains(search.ToUpper())
                    || p.Brand.Name!.ToUpper().Contains(search.ToUpper())
                    || p.SubCategory.Name.ToUpper().Contains(search.ToUpper())
                    || p.SupCategory.Name.ToUpper().Contains(search.ToUpper()))
                    .ToListAsync();

                return View("Index", products);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"SearchProductByName Error => {ex}");
                return View("Index");
            }
        }
    }
}
