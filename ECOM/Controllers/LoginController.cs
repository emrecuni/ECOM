using ECOM.Data;
using ECOM.Interface;
using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class LoginController : Controller
    {

        private readonly DataContext _context;
        private readonly ISmtp_Sender _sender;
        private readonly ILogger<LoginController> _logger;

        public LoginController(DataContext context, ISmtp_Sender sender, ILogger<LoginController> logger)
        {
            _context = context;
            _sender = sender;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                if (email is not null && password is not null)
                {
                    
                    var customer = await _context.Customers.FirstAsync(c => c.Email == email || c.Phone == email);
                    if (customer is not null && Encryption.VerifyPassword(password,customer.Password!))
                    {

                        var claims = new List<Claim>
                        {
                            new (ClaimTypes.Name, customer.Name!),
                            new (ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                            new (ClaimTypes.Role,customer.IsCustomer.ToString()!)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var autProperties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddDays(30)
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            autProperties);

                        return RedirectToAction("Index", "Main");
                    }
                    else // kullanıcı adı parola hatalı mesajı bastır
                    {
                        ViewBag.WrongPassword = "Email veya Parolanızı Kontrol Ediniz.";
                        return View();
                    }
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
                    Message = "Email veya Parolanızı Kontrol Ediniz.",
                    Title = "Giriş Yapılırken Bir Hata Oluştu."
                };
                _logger.LogError($"Login/Index(POST) Error => {ex}");
                return View("Error");
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

            return View("Forgot-Password");
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email) // parola sıfırlama isteği girilen mail adresine girilmelidir
        {
            try
            {
                if (email is null)
                {
                    ViewBag.Info = "E-Mail Alanı Boş Olamaz!";
                    ViewBag.IsSuccess = StatusTypes.Warning;
                    return View("Forgot-Password");
                }

                if (_sender.SendMail(email, "Parola Sıfırlama İsteği", "Aşağıdaki linke tıklayınız.")) // mail başarıyla gönderilirse
                {
                    ViewBag.IsSuccess = StatusTypes.Success;
                    ViewBag.Info = "Parola Sıfırlama İsteği Gönderildi.";
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) // parametreleri modele dönüştür
        {
            if (!ModelState.IsValid)
                return View(model);

            // kayıt olacak kullanıcın veri tabanında olup olmadığı kontrol edilir
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email || c.Phone == model.Phone);
            if (customer is not null) // müşteri kayıtlıysa
            {
                ViewBag.Info = "E-Mail veya Telefon Zaten Kayıtlı";
                ViewBag.IsSuccess = StatusTypes.Warning;
                return View(model);
            }

            try
            {
                var encryptedPassword = Encryption.HashPassword(model.Password!);

                Customers newCustomer = new()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Password = encryptedPassword,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    BirthDate = model.Birthdate,
                    AdditionTime = DateTime.Now,
                    IsCustomer = true
                };


                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
                ViewBag.Info = "Yeni Kayıt Başarılı.";
                ViewBag.IsSuccess = StatusTypes.Success;
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Register New Record Error => {ex}");
                ViewBag.Info = "Kayıt Sırasında Bir Hata Oluştu Tekrar Deneyiniz.";
                ViewBag.IsSuccess = StatusTypes.Error;
            }
            return View();
        }
    }
}
