using ECOM.Data;
using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(DataContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır

                var customer = await _context.Customers.FirstAsync(c => c.CustomerId == customerId);
                return View("Index", customer);
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
                return View ("Error", error);   
            }           
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

        [HttpPost]
        public IActionResult EditMembership(Customers customer)
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
