using ECOM.Models;
using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductApiClient _productService;
        private readonly ICustomerApiClient _customerService;
        private readonly ILogger<CartController> _logger;

        public CartController(IProductApiClient productService, ICustomerApiClient customerService, ILogger<CartController> logger)
        {
            _productService = productService;
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            try
            {
                var cartResult = await _productService.GetCartAsync(User.GetCustomerId(), ct);

                // api sepet boşken de Status.Failed döner; bu yüzden sadece http hatası ve Status.Error gerçek hata sayılır
                if (cartResult is null || !cartResult.IsSuccess || cartResult.Data is null || cartResult.Data.Status == Status.Error)
                {
                    Guid guid = Guid.NewGuid();
                    ErrorViewModel error = new ErrorViewModel
                    {
                        Message = $"Hata Kodu: {guid}",
                        RequestId = HttpContext.TraceIdentifier,
                        Title = "Sepet getirilirken bir hata oluştu."
                    };
                    _logger.LogError($"Cart/Index Error Hata Kodu: {guid} => {cartResult?.Data?.Message ?? cartResult?.ErrorMessage}");
                    return View("Error", error);
                }

                CartViewModel cartViewModel = new()
                {
                    Cart = cartResult.Data.Status == Status.Success ? cartResult.Data.Result : null
                };

                // favoriler gelmezse sepet sayfası yine açılır, sadece öneri bölümü boş kalır
                var favoriteResult = await _customerService.GetFavoritesAsync(User.GetCustomerId(), ct);
                if (favoriteResult.IsSuccess && favoriteResult.Data?.Status == Status.Success && favoriteResult.Data.Result is not null)
                    cartViewModel.Favorites = favoriteResult.Data.Result;

                return View(cartViewModel);
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = $"Hata Kodu: {guid}",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = "Sepet getirilirken bir hata oluştu."
                };
                _logger.LogError($"Cart/Index Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CartUpdateModel model, CancellationToken ct) // sepetteki ürünün adedini ve seçili durumunu günceller
        {
            try
            {
                if (model is null || model.Piece < 1)
                    return BadRequest(new { message = "Geçersiz adet." });

                var editResult = await _productService.EditCartAsync(new EditCartRequestDto
                {
                    CustomerId = User.GetCustomerId(),
                    ProductId = model.ProductId,
                    SellerId = model.SellerId,
                    Piece = model.Piece,
                    Enable = model.Enable
                }, ct);

                if (editResult is null || !editResult.IsSuccess || editResult.Data?.Status != Status.Success)
                    return BadRequest(new { message = editResult?.Data?.Message ?? editResult?.ErrorMessage ?? "Sepet güncellenemedi." });

                // güncel toplamlar api'nin hesapladığı sepetten alınır
                var cartResult = await _productService.GetCartAsync(User.GetCustomerId(), ct);
                var cart = cartResult?.Data?.Status == Status.Success ? cartResult.Data.Result : null;

                if (cartResult is null || !cartResult.IsSuccess || cart is null)
                    return BadRequest(new { message = cartResult?.Data?.Message ?? cartResult?.ErrorMessage ?? "Sepet getirilemedi." });

                var item = cart.Products?.FirstOrDefault(p => p.Id == model.ProductId && p.SellerId == model.SellerId);

                return Json(new
                {
                    totalPrice = cart.TotalPrice.ToString("F2"),
                    count = cart.Products?.Count(p => p.Enable) ?? 0,
                    itemPrice = item?.Price.ToString("F2")
                });
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _logger.LogError($"Cart/Update Error Hata Kodu: {guid} => {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Sepet güncellenirken bir hata oluştu. Hata Kodu: {guid}" });
            }
        }
    }
}
