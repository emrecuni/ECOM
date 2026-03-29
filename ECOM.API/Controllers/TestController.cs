using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Encryption(string plainText)
        {
            var hashed = Helpers.EncryptionHelper.HashPassword(plainText);
            return Ok(hashed);
        }

        public IActionResult Verify(string password, string stored)
        {
            var isValid = Helpers.EncryptionHelper.VerifyPassword(password, stored);
            return Ok(isValid);
        }
    }
}
