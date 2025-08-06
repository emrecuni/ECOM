using ECOM.Data;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View("Index");
        }

        public IActionResult Order()
        {
            //ViewBag.MenuId = "order";
            return View("Index");
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

        public IActionResult EditMembership()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult CommunicationSettings()
        {
            return View();
        }

        public IActionResult Cards()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Address(Addresses newAddress)
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır

                newAddress.CustomerId = customerId;
                newAddress.ReceiverId = customerId;
                newAddress.AdditionTime = DateTime.Now;


                _context.Addresses.Add(newAddress); // yeni adres eklenir

                await _context.SaveChangesAsync(); // veri tabanına kaydedilir

                return RedirectToAction("Index","Payment");
                
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Address Error => {ex}");
                return View("Error", new { message = "Adres eklenirken bir hata oluştu." });
            }
        }
    }
}
