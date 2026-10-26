using ECOM.Models;
using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;
using ECOM.MVC.OldFiles.Data;
using ECOM.MVC.OldFiles.Services;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Targets;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productService;
        private readonly DataContext _context;
        private readonly ProductDataProcess _product;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductApiClient productService, DataContext context, ProductDataProcess product, ILogger<ProductController> logger)
        {
            _productService = productService;
            _context = context;
            _product = product;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int id, CancellationToken ct)
        {
            try
            {
                var result = await _productService.GetProductDetailsAsync(new DetailProductRequestDto
                {
                    CustomerId = User.GetCustomerId(),
                    ProductId = id
                }, ct);

                if (result is null)
                {
                    ErrorViewModel error = new()
                    {
                        RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Message = "Message: Ürün detayı çekilirken bir hata oluştu.",
                        Title = "Ürün Sayfası Yüklenirken Bir Hata Oluştu."
                    };
                    _logger.LogError($"Product/Index Error ");
                    return View("Error", error);
                }
                else if (!result.IsSuccess)
                {
                    ErrorViewModel error = new()
                    {
                        RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Message = $"Message: {result.ErrorMessage}",
                        Title = "Ürün Sayfası Yüklenirken Bir Hata Oluştu."
                    };
                    _logger.LogError($"Product/Index Error ");
                    return View("Error", error);
                }
                else if (result.Data is not null && result.Data.Status != Status.Success)
                {
                    ErrorViewModel error = new()
                    {
                        RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Message = $"Message: {result.Data.Message}",
                        Title = "Ürün Sayfası Yüklenirken Bir Hata Oluştu."
                    };
                    _logger.LogError($"Product/Index Error ");
                    return View("Error", error);
                }
                return View(result!.Data!.Result);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Product Index Error => {ex}");
                return RedirectToAction("Index", "Main");
            }

        }

        [HttpPost]
        public async Task<IActionResult> SendComment(int id, int rate, string? review, string imagePath, CancellationToken ct)
        {
            if (rate < 1 || rate > 5)
                return BadRequest("Geçersiz puan değeri.");

            var result = await _productService.AddCommentAsync(new AddCommentRequestDto
            {
                CustomerId = User.GetCustomerId(),
                ProductId = id,
                Score = rate,
                Comment = review,
                ImagePath = imagePath
            }, ct);

            if (result is not null && result.IsSuccess && result.Data?.Status == Status.Success)           
                TempData["Info"] = "Yorumunuz Başarıyla Eklendi.";
            else
                TempData["Error"] = "Yorum eklenirken bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("Index", new { id = id });            
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(int productId, string productName, int sellerId, float price) // seçilen ürünü sepete ekler
        {
            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır

            // veri tabanında ilgili müşterinin ilgili ürün ve satıcıdan sepete eklediği bir ürünleri çeker
            var carts = await _context.Carts
                .FirstOrDefaultAsync(c => c.CustomerId == customerId && c.ProductId == productId && c.SellerId == sellerId && c.Enable == true);

            if (carts is not null)
            {
                carts.Piece++;
                carts.TotalPrice += decimal.Parse(price.ToString());
                _context.Carts.Update(carts);
            }
            else
            {
                Cart cart = new()
                {
                    CustomerId = customerId,
                    ProductId = productId,
                    Piece = 1,
                    SellerId = sellerId,
                    TotalPrice = decimal.Parse(price.ToString()),
                    Enable = true,
                    CreatedAt = DateTime.Now
                };
                _context.Carts.Add(cart);
            }

            await _context.SaveChangesAsync();

            //index/addcart'a gidiyor
            return RedirectToAction("Index", new { id = productId });
        }

        //[HttpPost]
        //public IActionResult Buy(int productId,string productName, float price) // seçilen ürünü doğrudan satın alma ekranına yönlendirir
        //{

        //    // direkt satın alma ekranın yönlendir
        //    //ViewBag.BuyProductName = productName;
        //    //ViewBag.BuyPrice = price;
        //    return RedirectToAction("Index",new {id = productId });
        //}
    }
}
