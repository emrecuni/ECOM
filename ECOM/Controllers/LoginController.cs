using ECOM.Data;
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
                    ViewBag.IsSuccess = "w";
                    return View("Forgot-Password");
                }

                _sender.SendMail(email);

                ViewBag.IsSuccess = "s";
                ViewBag.Info = "Parola Sıfırlama İsteği Gönderildi.";
                return View("Forgot-Password");
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"ForgotPassword Post Error => {ex}");
            }
            ViewBag.IsSuccess = "e";
            ViewBag.Info = "Bir Hata Oluştu Daha Sonra Tekrar Deneyiniz...";
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
