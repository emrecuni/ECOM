using ECOM.Data;
using ECOM.Models;
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

            }
            catch ( Exception ex)
            {

                throw;
            }
            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.SupCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            var comments = await _context.Comments
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
