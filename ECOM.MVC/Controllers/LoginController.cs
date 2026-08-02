using Azure.Core;
using ECOM.Models;
using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Models;
using ECOM.MVC.OldFiles.Data;
using ECOM.MVC.OldFiles.Interface;
using ECOM.MVC.OldFiles.Services;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.Enums;
//using Iyzipay;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly DataContext _context;
        private readonly IAuthApiClient _authApiClient;
        private readonly ISmtp_Sender _sender;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAuthApiClient authApiClient, DataContext context, HttpClient httpClient, ISmtp_Sender sender, ILogger<LoginController> logger)
        {
            _authApiClient = authApiClient;
            _context = context;
            _httpClient = httpClient;
            _sender = sender;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequestDto model, CancellationToken ct)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (model.Email is not null && model.Password is not null)
                {
                    _httpClient.BaseAddress = new Uri("http://localhost:5195/"); // API'nin temel URL'si

                    //var response = await _httpClient.PostAsJsonAsync("api/auth/token", new
                    //{
                    //    Email = model.Email,
                    //    Password = model.Password
                    //});

                    var result = await _authApiClient.TokenAsync(model, ct);

                    if (result is not null && result.IsSuccess && result.Data is not null)
                    {
                        var props = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = result.Data.ExpiresAt
                        };
                        props.StoreTokens(new[]
                        {
                            new AuthenticationToken { Name = "access_token", Value = result.Data.Token! }
                        });

                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(result.Data.Token);

                        var identity = new ClaimsIdentity(
                            jwt.Claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity),
                            props);

                        return RedirectToAction("Index", "Main");
                    }

                    ViewBag.WrongPassword = "Email veya Parolanızı Kontrol Ediniz.";
                    return View();
                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    ModelState.AddModelError("", "Giriş başarısız");
                    //    return View(model);
                    //}

                    //var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

                    //if (result is null || result.Token is null) // buradaki yönlendirmeyi kontrol et
                    //    return View(model);

                    //// Token'ı HttpOnly cookie'ye kaydet (XSS'e karşı koruma)
                    //Response.Cookies.Append("jwt_token", result!.Token, new CookieOptions
                    //{
                    //    HttpOnly = true,
                    //    Secure = true,
                    //    SameSite = SameSiteMode.Strict,
                    //    Expires = result.ExpiresAt
                    //});

                    //// MVC tarafı için cookie auth
                    //var handler = new JwtSecurityTokenHandler();
                    //var jwt = handler.ReadJwtToken(result.Token);

                    //var identity = new ClaimsIdentity(
                    //    jwt.Claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //await HttpContext.SignInAsync(
                    //    CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(identity),
                    //    new AuthenticationProperties { IsPersistent = true });

                    //return RedirectToAction("Index", "Main");

                    //var customer = await _context.Customers.FirstAsync(c => c.Email == model.Email || c.Phone == model.Email);
                    //if (customer is not null && Encryption.VerifyPassword(model.Password, customer.Password!))
                    //{

                    //    var claims = new List<Claim>
                    //    {
                    //        new (ClaimTypes.Name, customer.Name!),
                    //        new (ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                    //        new (ClaimTypes.Role,customer.IsCustomer.ToString()!)
                    //    };

                    //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //    var autProperties = new AuthenticationProperties
                    //    {
                    //        IsPersistent = true,
                    //        ExpiresUtc = DateTime.UtcNow.AddDays(30)
                    //    };

                    //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    //        new ClaimsPrincipal(claimsIdentity),
                    //        autProperties);

                    //    return RedirectToAction("Index", "Main");
                    //}
                    //else // kullanıcı adı parola hatalı mesajı bastır
                    //{
                    //    ViewBag.WrongPassword = "Email veya Parolanızı Kontrol Ediniz.";
                    //    return View();
                    //}
                }
                else
                {
                    ViewBag.NullCheck = "Email ve Parola Alanları Boş Olamaz!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel error = new()
                {
                    RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = $"Message: {ex.Message}\nStacktrace: {ex.StackTrace}",
                    Title = "Giriş Yapılırken Bir Hata Oluştu."
                };
                _logger.LogError($"Login/Index(POST) Error => {ex}");
                return View("Error", error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                ViewBag.IsSuccess = StatusTypes.Success;
                ViewBag.Info = "Başarıyla Çıkış Yapıldı.";
            }
            catch (Exception ex)
            {
                ViewBag.IsSuccess = StatusTypes.Error;
                ViewBag.Info = "Çıkış Yapılırken Bir Hata Oluştu.";
                NLogger.logger.Error($"Logout Error => {ex}");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.FormType = OtpProcessStatus.SendOtp;
            return View("Forgot-Password");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken ct) // parola sıfırlama isteği girilen mail adresine girilmelidir
        {
            try
            {
                if (email is null)
                {
                    ViewBag.Info = "E-Mail Alanı Boş Olamaz!";
                    ViewBag.IsSuccess = StatusTypes.Warning;
                    return View("Forgot-Password");
                }

                OtpRequestDto request = new()
                {
                    Email = email,
                    Purpose = OtpPurpose.ForgotPassword
                };

                var result = await _authApiClient.SendOtpAsync(request, ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                {
                    ViewBag.IsSuccess = StatusTypes.Success;
                    ViewBag.FormType = OtpProcessStatus.CheckOtp;
                    ViewBag.Info = "Parola Sıfırlama İsteği Gönderildi.";
                    ViewBag.Email = request.Email;
                    ViewBag.Purpose = request.Purpose;
                }
                else if (result is not null && result.IsSuccess && result.Data is not null)
                {
                    ViewBag.IsSuccess = StatusTypes.Warning;
                    ViewBag.Info = result.Data.Message;
                }
                else
                {
                    ViewBag.IsSuccess = StatusTypes.Error;
                    ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.IsSuccess = StatusTypes.Error;
                ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
                NLogger.logger.Error($"ForgotPassword Post Error => {ex}");
            }
            return View("Forgot-Password");
        }

        [HttpGet]
        public IActionResult VerifyOtpCode()
        {
            return RedirectToAction("ForgotPassword");
        }

        [HttpPost]
        public async Task<IActionResult> VerifyOtpCode(OtpRequestDto request, CancellationToken ct)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                var result = await _authApiClient.CheckOtpAsync(request, ct);

                if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
                {
                    ViewBag.IsSuccess = StatusTypes.Success;
                    ViewBag.Info = "Doğrulama Başarılı. Yeni Parolanızı Giriniz.";
                    ViewBag.FormType = OtpProcessStatus.VerificationOtp;
                }
                else if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Result is not null && result.Data.Result.AttemptCount == 3)
                {
                    ViewBag.IsSuccess = StatusTypes.Error;
                    ViewBag.Info = "3 Defa Hatalı Girdiniz. Tekrar Kod Alınız.";
                    ViewBag.FormType = OtpProcessStatus.SendOtp;
                }
                else if (result is not null && result.IsSuccess)
                {
                    ViewBag.IsSuccess = StatusTypes.Warning;
                    ViewBag.Info = result.Data?.Message;
                    ViewBag.FormType = OtpProcessStatus.CheckOtp;
                }
                else
                {
                    ViewBag.IsSuccess = StatusTypes.Error;
                    ViewBag.Info = "Doğrulama Başarısız. Tekrar Deneyiniz.";
                    ViewBag.FormType = OtpProcessStatus.CheckOtp;
                }
                ViewBag.Email = request.Email;
                ViewBag.MaskedEmail = string.Concat(request.Email.Substring(0, 1), "***", request.Email.Substring(request.Email.IndexOf('@')));
                ViewBag.Purpose = request.Purpose;
            }
            catch (Exception ex)
            {
                ViewBag.IsSuccess = StatusTypes.Error;
                ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
                NLogger.logger.Error($"VerifyOtpCode  Post Error => {ex}");
            }
            if (request.Purpose == OtpPurpose.ForgotPassword)
                return View("Forgot-Password");
            else if (request.Purpose == OtpPurpose.Register)
                return View("Register");
            else
                return View("Index");
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return RedirectToAction("ForgotPassword");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDto model, CancellationToken ct)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Forgot-Password");

                var result = await _authApiClient.ResetPasswordAsync(model, ct);

                if (result is not null && result.IsSuccess)
                {
                    ViewBag.IsSuccess = StatusTypes.Success;
                    ViewBag.Info = "Parola Başarıyla Değiştirildi.\n\n" +
                        "Yeniden Giriş Yapınız.";
                }
                else
                {
                    ViewBag.IsSuccess = StatusTypes.Error;
                    ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.IsSuccess = StatusTypes.Error;
                ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
                NLogger.logger.Error($"ResetPassword Post Error => {ex}");
            }
            return View("Forgot-Password");
        }

        [HttpGet]
        public IActionResult RegisterEmail()
        {
            return RedirectToAction("Register");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEmail(RegisterRequestDto model, CancellationToken ct)
        {
            if (model is null || model.Email is null)
                return View("Register");

            CheckCustomerDto checkCustomerDto = new()
            {
                Email = model.Email
            };

            var checkExistsCustomer = await _authApiClient.CheckExistsCustomer(checkCustomerDto, ct);

            if (checkExistsCustomer?.Data?.Result == true)
            {
                ViewBag.IsSuccess = StatusTypes.Warning;
                ViewBag.Info = checkExistsCustomer.Data.Message;
                ViewBag.FormType = OtpProcessStatus.SendOtp;
                return View("Register");
            }

            OtpRequestDto otpRequest = new()
            {
                Email = model.Email,
                Purpose = OtpPurpose.Register
            };

            var result = await _authApiClient.SendOtpAsync(otpRequest, ct);

            if (result is not null && result.IsSuccess && result.Data is not null && result.Data.Status == Status.Success)
            {
                ViewBag.IsSuccess = StatusTypes.Success;
                ViewBag.FormType = OtpProcessStatus.CheckOtp;
                ViewBag.Info = "Parola Sıfırlama İsteği Gönderildi.";
                ViewBag.Email = otpRequest.Email;
                ViewBag.MaskedEmail = string.Concat(otpRequest.Email.Substring(0, 1), "***", otpRequest.Email.Substring(otpRequest.Email.IndexOf('@')));
                ViewBag.Purpose = otpRequest.Purpose;
            }
            else if (result is not null && result.IsSuccess && result.Data is not null)
            {
                ViewBag.IsSuccess = StatusTypes.Warning;
                ViewBag.Info = result.Data.Message;
            }
            else
            {
                ViewBag.IsSuccess = StatusTypes.Error;
                ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
            }

            return View("Register");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.FormType = OtpProcessStatus.SendOtp;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto model,CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _authApiClient.RegisterAsync(model, ct);

            if( response is not null && response.IsSuccess && response.Data is not null && response.Data.Status == Status.Success)
            {
                ViewBag.IsSuccess = StatusTypes.Success;
                ViewBag.Info = "Kayıt Başarılı. Giriş Yapabilirsiniz.";
                ViewBag.FormType = OtpProcessStatus.Done;
                return View();
            }
            else if (response is not null && response.IsSuccess && response.Data is not null)
            {
                ViewBag.IsSuccess = StatusTypes.Warning;
                ViewBag.Info = response.Data.Message;
            }
            else
            {
                ViewBag.IsSuccess = StatusTypes.Error;
                ViewBag.Info = "Bir Hata Oluştu Tekrar Deneyiniz.";
            }


            return RedirectToAction("RegisterEmail", model);
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model) // parametreleri modele dönüştür
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    // kayıt olacak kullanıcın veri tabanında olup olmadığı kontrol edilir
        //    var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email || c.Phone == model.Phone);
        //    if (customer is not null) // müşteri kayıtlıysa
        //    {
        //        ViewBag.Info = "E-Mail veya Telefon Zaten Kayıtlı";
        //        ViewBag.IsSuccess = StatusTypes.Warning;
        //        return View(model);
        //    }

        //    try
        //    {
        //        var encryptedPassword = Encryption.HashPassword(model.Password!);

        //        Customers newCustomer = new()
        //        {
        //            Name = model.Name,
        //            Surname = model.Surname,
        //            Email = model.Email,
        //            Password = encryptedPassword,
        //            Phone = model.Phone,
        //            Gender = model.Gender,
        //            BirthDate = model.Birthdate,
        //            AdditionTime = DateTime.Now,
        //            IsCustomer = true
        //        };

        //        _context.Customers.Add(newCustomer);
        //        await _context.SaveChangesAsync();
        //        ViewBag.Info = "Yeni Kayıt Başarılı.";
        //        ViewBag.IsSuccess = StatusTypes.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        NLogger.logger.Error($"Register New Record Error => {ex}");
        //        ViewBag.Info = "Kayıt Sırasında Bir Hata Oluştu Tekrar Deneyiniz.";
        //        ViewBag.IsSuccess = StatusTypes.Error;
        //    }
        //    return View();
        //}
    }
}
