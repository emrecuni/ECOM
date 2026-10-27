using ECOM.Models;
using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;
using ECOM.MVC.OldFiles.Data;
using ECOM.MVC.OldFiles.Interface;
using ECOM.MVC.OldFiles.Services;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerApiClient _customerService;
        private readonly IAuthApiClient _authService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ICustomerApiClient customerService, IAuthApiClient authService, ILogger<AccountController> logger)
        {
            _customerService = customerService;
            _authService = authService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            try
            {
                AccountViewModel accountViewModel = new();
                var result = await _customerService.GetCustomerByIdAsync(User.GetCustomerId(), ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                {
                    var customer = result.Data?.Result;
                    if (customer is null)
                        return RedirectToAction("Error", "Home"); // ya da uygun hata davranışı

                    accountViewModel.Customers = customer;
                    accountViewModel.Orders = [];
                    accountViewModel.Coupons = [];
                    accountViewModel.Favorites = [];
                }

                return View("Index", accountViewModel);
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = "Hesap bilgileri getirilirken bir hata oluştu.",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = $"Hata Kodu: {guid}"
                };
                _logger.LogError($"Account/Index Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }

        public async Task<IActionResult> Order(CancellationToken ct)
        {
            try
            {
                var result = await _customerService.GetOrdersAsync(User.GetCustomerId(), ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                {
                    var orders = result.Data?.Result;
                    if (orders is null)
                        return RedirectToAction("Error", "Home"); // ya da uygun hata davranışı                    
                    return View("Order", orders);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = "Hesap bilgileri getirilirken bir hata oluştu.",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = $"Hata Kodu: {guid}"
                };
                _logger.LogError($"Account/Order Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }

        public IActionResult Favorite()
        {
            return View("Index");
        }

        public IActionResult Coupon()
        {
            return View("Index");
        }

        public IActionResult Rating()
        {
            return View();
        }

        public IActionResult Exit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditMembership(BasicCustomerRequestDto customer, CancellationToken ct)
        {
            try
            {
                var result = await _customerService.ChangeBasicInfoAsync(customer, ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, result?.Data?.Message ?? result?.ErrorMessage ??"Üyelik bilgileri güncellenirken bir hata oluştu.");
                    return View("Index", customer);
                }
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = $"Hata Kodu: {guid}",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = "Üyelik bilgileri güncellenirken bir hata oluştu."
                };
                _logger.LogError($"Account/EditMembership Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(string password, string newPassword, string againPassword, CancellationToken ct)
        {
            try
            {
                // form alan adları (password, newPassword, againPassword) api'nin beklediği dto'ya çevrilir
                ChangePasswordRequestDto request = new()
                {
                    CustomerId = User.GetCustomerId(),
                    OldPassword = password,
                    NewPassword = newPassword,
                    ReNewPassword = againPassword
                };

                var result = await _customerService.ChangePasswordAsync(request, ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                    TempData["Info"] = result.Data.Message ?? "Parolanız başarıyla güncellendi.";
                else
                    TempData["Error"] = result?.Data?.Message ?? result?.ErrorMessage ?? "Parola değiştirilirken bir hata oluştu.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = $"Hata Kodu: {guid}",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = "Parola değiştirilirken bir hata oluştu."
                };
                _logger.LogError($"Account/ChangePassword Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }

        }

        [HttpPost]
        public IActionResult CommunicationSettings()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = $"Hata Kodu: {guid}",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = "Parola değiştirilirken bir hata oluştu."
                };
                _logger.LogError($"Account/CommunicationSettings Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCommunicationSettings(string? email, string? phone, string? verificationCode, CancellationToken ct)
        {
            try
            {
                // ajax ile çağrıldığı için sonuç json olarak döner; kodun doğruluğu api tarafında kontrol edilir
                ContactInfoRequestDto request = new()
                {
                    CustomerId = User.GetCustomerId(),
                    NewEmail = email,
                    NewPhone = phone,
                    VerificationCode = verificationCode
                };

                var result = await _customerService.ChangeContactInfoAsync(request, ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                    return Json(new { success = true, message = result.Data.Message ?? "İletişim bilgileriniz güncellendi." });

                return Json(new { success = false, message = result?.Data?.Message ?? result?.ErrorMessage ?? "İletişim bilgileri güncellenirken bir hata oluştu." });
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = $"Hata Kodu: {guid}",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = "Parola değiştirilirken bir hata oluştu."
                };
                _logger.LogError($"Account/EditCommunicationSettings Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendOTPCode(CancellationToken ct)
        {
            try
            {
                // kod, istemciden gelen adrese değil müşterinin kayıtlı e-postasına gönderilir
                var customerResult = await _customerService.GetCustomerByIdAsync(User.GetCustomerId(), ct);
                var email = customerResult?.Data?.Result?.Email;

                if (customerResult is null || !customerResult.IsSuccess || customerResult.Data?.Status != Status.Success || string.IsNullOrWhiteSpace(email))
                    return BadRequest(new { message = "Müşteri bilgileri getirilemedi." });

                // kod api tarafında üretilip db'ye hash'li yazılır ve sadece e-postayla gider; view'a hiç gelmez
                var result = await _authService.SendOtpAsync(new OtpRequestDto
                {
                    Email = email,
                    Purpose = OtpPurpose.ChangeEmail
                }, ct);

                if (result is null || !result.IsSuccess || result.Data?.Status != Status.Success)
                    return BadRequest(new { message = result?.Data?.Message ?? result?.ErrorMessage ?? "Doğrulama kodu gönderilemedi." });

                return PartialView("ChangeEmail");
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _logger.LogError($"Account/SendOTPCode Error Hata Kodu: {guid} => {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Doğrulama kodu gönderilirken bir hata oluştu. Hata Kodu: {guid}" });
            }
        }

        public IActionResult Cards()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Address(string? name, string? surname, string? phone, string? addressName, string? address,
            int? cityId, int? districtId, int? neighbourhoodId, CancellationToken ct)
        {
            try
            {
                // payment sayfasındaki yeni adres formunun alanları api'nin beklediği dto'ya çevrilir
                AddressRequestDto request = new()
                {
                    CustomerId = User.GetCustomerId(),
                    Address = new AddressCreateDto
                    {
                        AddressName = addressName,
                        Address = address,
                        City = cityId,
                        District = districtId,
                        Neighbourhood = neighbourhoodId
                    },
                    Receiver = new ReceiverDto
                    {
                        Name = name,
                        Surname = surname,
                        Phone = phone
                    }
                };

                var result = await _customerService.AddAddressAsync(request, ct);

                if (result is null || !result.IsSuccess || result.Data is null || result.Data.Status != Status.Success)
                    TempData["Error"] = result?.Data?.Message ?? result?.ErrorMessage ?? "Adres eklenirken bir hata oluştu.";

                return RedirectToAction("Index", "Payment");
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = $"Hata Kodu: {guid}",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = "Adres eklenirken bir hata oluştu."
                };
                _logger.LogError($"Account/Address Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }
    }
}
