using ECOM.Data;
using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Targets;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly ProductDataProcess _product;

        public ProductController(DataContext context, ProductDataProcess product)
        {
            _context = context;
            _product = product;
        }

        public async Task<IActionResult> Index(int id)
        {
            try
            {

                var productViewModel = await _product.GetProductWithCommentsById(id);

                if (productViewModel?.Product is null) // ürün bulunamazsa hata mesajı döndürsün
                    return NotFound();

                return View(productViewModel);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Product Index Error => {ex}");
                return RedirectToAction("Index", "Main");
            }

        }

        [HttpPost]
        public async Task<IActionResult> SendComment(int id, int rate, string? review)
        {
            if (rate < 1 || rate > 5)
                return BadRequest("Geçersiz puan değeri.");

            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var newComment = new Comments
            {
                Comment = review,
                ProductId = id,
                Score = rate,
                CustomerId = customerId
            };

            _context.Comments.Add(newComment); // yorum comments tablosuna insert edilir
            await _context.SaveChangesAsync();

            var productViewModel = await _product.GetProductWithCommentsById(id);
            if (productViewModel is null) // ürün bulunamazsa hata mesajı döndürsün
                return NotFound();

            var scores = await _context.Comments
                .Where(c => c.ProductId == id && c.Score != null)
                .Select(c => c.Score!.Value)
                .ToListAsync();

            productViewModel.Product!.Score = float.Parse(scores.Average().ToString("0.0"));

            _context.Products.Update(productViewModel.Product); // ürün skoru güncellenir
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = id });
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
