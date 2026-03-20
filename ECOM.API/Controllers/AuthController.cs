using System.Security.Cryptography;
using System.Text;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
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
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IAuthService authService,
            IJwtService jwtService,
            IConfiguration config,
            ILogger<AuthController> logger)
        {
            _authService = authService;
            _jwtService = jwtService;
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
                    ExpiresAt = DateTime.Now.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthController/Login Error ==> {ex}");
                return Unauthorized(new { message = "Bir hata oluştu." });
            }
        }

        [AllowAnonymous]
        [HttpPost("sendotp")]
        public async Task<IActionResult> SendOtp(RegisterRequestDto model)
        {
            if (model is null || !ModelState.IsValid)
                return BadRequest("Model is null");

            Response<SmtpResponseDto> response = new();

            #region Kullanıcı var mı kontrolü
            var isExistsCustomer = await _authService.CheckExistsCustomer(model);

            if (isExistsCustomer) // kayıt edilmeye çalışılan telefon veya email ile bir müşteri kayıtlıysa
                return Ok(response = new()
                {
                    Message = "Bu telefon veya email ile kayıtlı bir müşteri bulunmaktadır.",
                    Status = Status.Default
                });
            #endregion

            #region OTP oluşturma, db'ye yazma ve gönderme
            string otpCode = RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6"); // 6 hane, başına 0 ekler
            Console.WriteLine($"Auth/Register ==> otpCode: {otpCode}");

            OtpRequestDto modelOtp = new()
            {
                Email = model.Email,
                Purpose = OtpPurpose.Register,
                CodeHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(otpCode))) // otp kodunu hash'leyerek db'ye kaydederiz, böylece güvenliği artırırız
            };

            if(await _authService.SaveOtpCode(modelOtp) == false) // db'ye yazılamazsa otp'yi göndermez
                return Ok(response = new()
                {
                    Message = "OTP kodu oluşturulamadı. Lütfen tekrar deneyiniz.",
                    Status = Status.Error,
                });
            
            SmtpRequestDto request = new()
            {
                From = _config["Smtp:SenderMail"],
                Recipients = new List<string>
                {
                    model.Email
                },
                Subject = "ECOM Doğrulama Kodu",
                Body = System.IO.File.ReadAllText("wwwroot/StaticFiles/otp.html")
                         .Replace("{{OTP_CODE}}", otpCode),
                IsBodyHtml = true
            };

            Console.WriteLine($"Auth/Register ==> mail gönderiliyor.");
            response = await _authService.SendVerifyEmail(request);
            response.Message = $"OTP Code: {otpCode}";
            #endregion

            Console.WriteLine($"Auth/Register ==> {(response.Status == Status.Success ? """Mail Gönderimi başarılı""" : """mail gönderimi başarısız""")}");
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("checkotp")]
        public async Task<IActionResult> CheckOtp(OtpRequestDto model)
        {
            if (model is null || !ModelState.IsValid)
                return BadRequest("Model is null");

            // OTP doğrulama yapılır. 
            var response = await _authService.CheckOtpInDb(model);

            return Ok(response);
        }
    }
}