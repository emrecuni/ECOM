using ECOM.Data;
using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class LoginController : Controller
    {

        private readonly DataContext _context;
        private readonly Smtp_Sender _sender;

        public LoginController(DataContext context, Smtp_Sender sender)
        {
            _context = context;
            _sender = sender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            if (email is not null && password is not null)
            {
                var customer = await _context.Customers.Where(c => c.Email == email || c.Phone == email && c.Password == password).ToListAsync();
                if (customer.Count > 0)
                    return RedirectToAction("Index", "Main");
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

        public IActionResult Logout()
        {
            return View();
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

                if (_sender.SendMail(email)) // mail başarıyla gönderilirse
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
        public IActionResult Register(string name, string surname, string email, string password) // parametreleri modele dönüştür
        {
            ViewBag.Info = "Yeni Kayıt Başarılı";
            return View("Index");
        }
    }
}
