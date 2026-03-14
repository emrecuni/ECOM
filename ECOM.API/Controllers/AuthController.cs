using ECOM.Shared.Data.DTOs;
using ECOM.API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, IJwtService jwtService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            try
            {
                Console.WriteLine($"Login attempt with Email: {model.Email}");
                if (model is null)
                    return Unauthorized(new { message = "Geçersiz model." });

                var customer = await _authService.ValidateUser(model);

                if (customer is null)
                    return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre." });

                var token = _jwtService.GenerateToken(customer);

                return Ok(new LoginResponseDto
                {
                    Token = token,
                    Name = customer.Name,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthController/Login Error ==> {ex}");
                return Unauthorized(new { message = "Bir hata oluştu." });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto model)
        {
            if (model is null || !ModelState.IsValid)
                return BadRequest("Model is null");

            var isExistsCustomer = await _authService.CheckExistsCustomer(model);

            if(!isExistsCustomer) // kayıt edilmeye çalışılan telefon veya email ile bir müşteri kayıtlıysa
                return BadRequest("Bu telefon veya email ile kayıtlı bir müşteri bulunmaktadır.");

            // doğrulama kodu gönder


            return View();
        }
    }
}