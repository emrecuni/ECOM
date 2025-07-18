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

                var productViewModel = await _product.GetProduct(id);

                if (productViewModel is null) // ürün bulunamazsa hata mesajı döndürsün
                    NotFound();

                return View(productViewModel);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Product Index Error => {ex}");
                return RedirectToAction("Index", "Main");
            }

        }

        [HttpPost]
        public async Task<IActionResult> SendComment(string? comment, int rate,int id)
        {
            ViewBag.Comment = comment;
            ViewBag.Rate = rate;
            ViewBag.CommentInfo = "Yorum Başarıyla Eklendi.";

            var productViewModel = await _product.GetProduct(id);

            if (productViewModel is null) // ürün bulunamazsa hata mesajı döndürsün
                NotFound();

            return View("Index", productViewModel);
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
