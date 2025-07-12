using ECOM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class LoginController : Controller
    {

        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
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
            ViewBag.IsSuccess = false;
            return View("Forgot-Password");
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email) // parola sıfırlama isteği girilen mail adresine girilmelidir
        {
            if (email is null)
            {
                ViewBag.Info = "E-Mail Alanı Boş Olamaz!";
                ViewBag.IsSuccess = false;
                return View("Forgot-Password");
            }


            ViewBag.IsSuccess = true;
            ViewBag.Info = "Parola sıfırlama isteği gönderildi.";
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
