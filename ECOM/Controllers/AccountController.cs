using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(string id)
        {

            return View("Index", new { tab = id });
        }

        public IActionResult Order()
        {
            //ViewBag.MenuId = "order";
            return View();
        }

        public IActionResult Favorite()
        {
            return View();
        }

        public IActionResult Coupon()
        {
            return View();
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

        public IActionResult Addres()
        {
            return View();
        }
    }
}
