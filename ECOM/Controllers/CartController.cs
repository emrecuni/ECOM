using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
