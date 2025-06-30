using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
