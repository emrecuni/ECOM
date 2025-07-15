using ECOM.Data;
using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.SupCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.ProductId == id);

                List<Comments> comments = new();

                if (product is not null) // ürün db'de varsa yorumları çekilir
                    comments = await _context.Comments
                       .Include(c => c.Product)
                       .Include(c => c.Customer)
                       .Where(p => p.ProductId == id)
                       .ToListAsync();

                ProductDetailViewModel viewModel = new()
                {
                    Product = product,
                    Comments = comments
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Product Index Error => {ex}");
                return RedirectToAction("Index", "Main");
            }

        }

        [HttpPost]
        public IActionResult SendComment(string comment, int rate)
        {
            ViewBag.Comment = comment;
            ViewBag.Rate = rate;
            ViewBag.CommentInfo = "Yorum Başarıyla Eklendi.";
            return View("Index");
        }

        public IActionResult AddCart(string productName, float price) // seçilen ürünü sepete ekler
        {
            ViewBag.CartProductName = productName;
            ViewBag.CartPrice = price;
            return View("Index");
        }

        public IActionResult Buy(string productName, float price) // seçilen ürünü doğrudan satın alma ekranına yönlendirir
        {

            // direkt satın alma ekranın yönlendir
            ViewBag.BuyProductName = productName;
            ViewBag.BuyPrice = price;
            return View("Index");
        }
    }
}
