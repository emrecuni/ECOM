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
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var customer = await _context.Customers.Where(c => c.Email == username && c.Password == password).ToListAsync();
                if (customer.Count > 0)
                    return RedirectToAction("Index", "Main");
                else // kullanıcı adı parola hatalı mesajı bastır
                {
                    ViewBag.WrongPassword = "Email veya Parolanızı Kontrol Ediniz.";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.NullCheck = "Email ve Parola Alanları Boş Olamaz!";
                return View("Index");
            }                
        }

        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.ForgotPassword = true;
            return View("Forgot-Password");
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email) // parola sıfırlama isteği girilen mail adresine girilmelidir
        {
            ViewBag.Info = "Parola sıfırlama isteği gönderildi.";
            return View();
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
