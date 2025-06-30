using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
