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
            var newComment = new Comments
            {
                Comment = review,
                ProductId = id,
                Score = rate,
                CustomerId = 1
            };

            _context.Comments.Add(newComment); // yorum comments tablosuna insert edilir
            await _context.SaveChangesAsync();


            var productViewModel = await _product.GetProductWithCommentsById(id);
            if (productViewModel is null) // ürün bulunamazsa hata mesajı döndürsün
                return NotFound();

            int totalScore = 0;
            float average = 0;


            foreach (var comment in productViewModel.Comments)
            {
                if (comment.Score is not null)
                    totalScore += comment.Score.Value;

            }

            average = (float)totalScore / productViewModel.Comments.Count;

            productViewModel.Product!.Score = average;

            _context.Products.Update(productViewModel.Product);
            await _context.SaveChangesAsync();



            return View("Index", productViewModel); // id'yi 0 gönderiyor
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
