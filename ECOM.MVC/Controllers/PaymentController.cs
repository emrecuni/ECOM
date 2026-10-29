using ECOM.Models;
using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;
using ECOM.Shared.Data.DTOs.Location;
using ECOM.Shared.Data.DTOs.Payment;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentApiClient _paymentService;
        private readonly IProductApiClient _productService;
        private readonly ICustomerApiClient _customerService;
        private readonly ILocationApiClient _locationService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentApiClient paymentService, IProductApiClient productService, ICustomerApiClient customerService,
            ILocationApiClient locationService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _productService = productService;
            _customerService = customerService;
            _locationService = locationService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            try
            {
                int customerId = User.GetCustomerId();

                // api sepet boşken Status.Failed döner; ödeme sayfasında boş sepetle işlem yapılamayacağı için sepete yönlendirilir
                var cartResult = await _productService.GetCartAsync(customerId, ct);
                if (cartResult is null || !cartResult.IsSuccess || cartResult.Data is null || cartResult.Data.Status == Status.Error)
                    return PaymentError($"Payment/Index sepet => {cartResult?.Data?.Message ?? cartResult?.ErrorMessage}", "Sepet getirilirken bir hata oluştu.");

                var cart = cartResult.Data.Status == Status.Success ? cartResult.Data.Result : null;
                if (cart?.Products is null || !cart.Products.Any(p => p.Enable))
                    return RedirectToAction("Index", "Cart");

                // adresi olmayan müşteride api Status.Failed döner, bu durumda liste boş kalır ve yeni adres formu kullanılır
                var addressResult = await _customerService.GetAddressAsync(customerId, ct);
                if (!addressResult.IsSuccess || addressResult.Data is null || addressResult.Data.Status == Status.Error)
                    return PaymentError($"Payment/Index adres => {addressResult.Data?.Message ?? addressResult.ErrorMessage}", "Adresler getirilirken bir hata oluştu.");

                var cityResult = await _locationService.GetCitiesAsync(ct);
                if (!cityResult.IsSuccess || cityResult.Data?.Status != Status.Success)
                    return PaymentError($"Payment/Index şehir => {cityResult.Data?.Message ?? cityResult.ErrorMessage}", "Şehirler getirilirken bir hata oluştu.");

                AddressViewModel model = new()
                {
                    Addresses = addressResult.Data.Result?.Addresses ?? [],
                    Cart = cart,
                    Cities = cityResult.Data.Result ?? []
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return PaymentError($"Payment/Index => {ex}", "Ödeme sayfası yüklenirken bir hata oluştu.");
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDistrictsAsync(int cityId, CancellationToken ct)
        {
            try
            {
                var result = await _locationService.GetDistrictsAsync(cityId, ct);

                if (!result.IsSuccess || result.Data?.Status != Status.Success)
                    return Json(new List<DistrictDto>());

                return Json(result.Data.Result?.OrderBy(d => d.Name).ToList() ?? []);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Payment/GetDistricts Error => {ex}");
                return Json(new List<DistrictDto>());
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetNeighbourhoodsAsync(int districtId, CancellationToken ct)
        {
            try
            {
                var result = await _locationService.GetNeighbourhoodsAsync(districtId, ct);

                if (!result.IsSuccess || result.Data?.Status != Status.Success)
                    return Json(new List<NeighbourhoodDto>());

                return Json(result.Data.Result?.OrderBy(n => n.Name).ToList() ?? []);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Payment/GetNeighbourhoods Error => {ex}");
                return Json(new List<NeighbourhoodDto>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Pay(int? addressId, CancellationToken ct)
        {
            try
            {
                if (addressId is null)
                {
                    ViewBag.ErrorMessage = "Adres seçimi yapınız.";
                    return View("Error");
                }

                // sepet, adres ve iyzico ödeme formu api tarafında hazırlanır
                var result = await _paymentService.PayAsync(new PaymentRequestDto
                {
                    CustomerId = User.GetCustomerId(),
                    AddressId = addressId.Value
                }, ct);

                if (result.IsSuccess && result.Data?.Status == Status.Success && !string.IsNullOrEmpty(result.Data.Result?.Content))
                {
                    ViewBag.CheckoutFormContent = result.Data.Result.Content; // Iyzico'dan gelen ödeme formu içeriği
                    return View();
                }

                ViewBag.ErrorMessage = result.Data?.Result?.ErrorMessage ?? result.Data?.Message ?? result.ErrorMessage ?? "Ödeme başlatılamadı.";
                return View("Error");
            }
            catch (Exception ex)
            {
                return PaymentError($"Payment/Pay => {ex}", "Ödeme başlatılırken bir hata oluştu.");
            }
        }

        // iyzico ödeme sonrası buraya cross-site form post yapar; SameSite cookie gönderilmeyebileceği için oturum aranmaz,
        // api ödeme oturumunu token üzerinden bulur
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Callback([FromForm] string? token, CancellationToken ct)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    ViewBag.ErrorMessage = "Ödeme bilgisi bulunamadı.";
                    return View("Error");
                }

                var result = await _paymentService.CallbackAsync(new CallbackRequestDto { Token = token }, ct);

                if (result.IsSuccess && result.Data?.Status == Status.Success && result.Data.Result is not null)
                {
                    ViewBag.PaymentStatus = "Ödeme Başarılı";
                    ViewBag.PaymentId = result.Data.Result.PaymentId;
                    ViewBag.Price = result.Data.Result.Price.ToString("F2");

                    return View("Success");
                }

                ViewBag.ErrorMessage = result.Data?.Result?.ErrorMessage ?? result.Data?.Message ?? result.ErrorMessage ?? "Ödeme tamamlanamadı.";
                return View("Error");
            }
            catch (Exception ex)
            {
                return PaymentError($"Payment/Callback => {ex}", "Ödeme sonucu alınırken bir hata oluştu.");
            }
        }

        // Views/Payment/Error.cshtml mesajı ViewBag.ErrorMessage'dan okur
        private IActionResult PaymentError(string logMessage, string userMessage)
        {
            Guid guid = Guid.NewGuid();
            _logger.LogError($"Hata Kodu: {guid} {logMessage}");
            ViewBag.ErrorMessage = $"{userMessage} Hata Kodu: {guid}";
            return View("Error");
        }
    }
}
