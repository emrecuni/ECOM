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
        private readonly ISmtpService _smtpService;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IAuthService authService,
            IJwtService jwtService,
            ISmtpService smtpService,
            IConfiguration config,
            ILogger<AuthController> logger)
        {
            _authService = authService;
            _jwtService = jwtService;
            _smtpService = smtpService;
            _config = config;
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

            Response<SmtpResponseDto> response;

            Console.WriteLine($"Auth/Register ==> Register Metodu çalıştı.");
            var isExistsCustomer = await _authService.CheckExistsCustomer(model);
            Console.WriteLine($"Auth/Register ==> {model.Email} ile {(isExistsCustomer ?  """kayıt zaten var""": """kayıt bulunamadı. Doğrulama kodu gönderiliyor""")}");
            if (isExistsCustomer) // kayıt edilmeye çalışılan telefon veya email ile bir müşteri kayıtlıysa
                return BadRequest(response = new()
                {
                    Message = "Bu telefon veya email ile kayıtlı bir müşteri bulunmaktadır.",
                    Status = Status.Error
                });

            // doğrulama kodu gönder
            SmtpRequestDto request = new()
            {
                From = _config["Smtp:SenderMail"],
                Recipients = new List<string>
                {
                    model.Email
                },
                Subject = "ECOM Doğrulama Kodu",
                Body = "Ecom Kayıt Doğrulama Kodunuz: \n\n123456",                
            };

            Console.WriteLine($"Auth/Register ==> mail gönderiliyor.");
            response = await _smtpService.SendEmailAsync(request);
             

            Console.WriteLine($"Auth/Register ==> {(response.Status == Status.Success ? """Mail Gönderimi başarılı""": """mail gönderimi başarısız""")}");
            return Ok(response);
        }
    }
}