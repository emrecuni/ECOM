using System.Security.Cryptography;
using System.Text;
using ECOM.Api.Data.Entities;
using ECOM.API.Data;
using ECOM.API.Data.Entities;
using ECOM.API.Helpers;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly ISmtpService _smtpService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(DataContext context, ISmtpService smtpService, ILogger<AuthService> logger)
        {
            _context = context;
            _smtpService = smtpService;
            _logger = logger;
        }

        // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner
        public async Task<Customers?> ValidateUser(LoginRequestDto model)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email || c.Phone == model.Email);

                if (customer is null || !EncryptionHelper.VerifyPassword(model.Password, customer.Password!))
                    return null;

                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/LoginAsync Error => {ex}");
                return null;
            }
        }

        // kullanıcı kaydını yapar
        public Task<Customers> Register(RegisterRequestDto model)
        {
            throw new NotImplementedException();
        }

        // email veya telefon numarası ile müşteri var mı kontrol eder, varsa true döner, yoksa false döner
        public async Task<bool> CheckExistsCustomer(RegisterRequestDto model)
        {
            var isExistsCustomer = await _context.Customers.AnyAsync(c => c.Email == model.Email || c.Phone == model.Phone);

            return isExistsCustomer;
        }

        // doğrulama kodunu email ile gönderir
        public async Task<Response<SmtpResponseDto>> SendVerifyEmail(SmtpRequestDto model)
        {
            return await _smtpService.SendEmailAsync(model);
        }

        // doğrulama kodunu veritabanına kaydeder, eski kodları temizler
        public async Task<bool> SaveOtpCode(OtpRequestDto model)
        {
            try
            {
                EmailVerification otpEntity = new EmailVerification
                {
                    Email = model.Email,
                    CodeHash = model.CodeHash,
                    ExpiredAt = DateTime.Now.AddMinutes(3),
                    IsUsed = false,
                    CanUsed = true,
                    Purpose = model.Purpose,
                    CreatedAt = DateTime.Now
                };

                // Eski OTP'leri temizle
                await _context.Verifications.Where(v => v.Email == otpEntity.Email &&
                   v.Purpose == otpEntity.Purpose &&
                   (v.ExpiredAt < DateTime.Now ||
                    v.AttemptCount >= 3 ||
                    v.CanUsed == true))
                   .ExecuteDeleteAsync();

                await _context.Verifications.AddAsync(otpEntity); // db'ye yeni OTP kaydı ekle
                await _context.SaveChangesAsync(); // değişiklikleri kaydet
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/SaveOtpCode ==> Error: {ex}");
                return false;
            }
        }

        public async Task<Response<OtpResponseDto>> CheckOtpInDb(OtpRequestDto model)
        {
            Response<OtpResponseDto> response = new();
            try
            {
                // db'den email ve amaca göre OTP kaydını getir
                var otpCode = await _context.Verifications.FirstOrDefaultAsync(v => v.Email == model.Email &&
                   v.Purpose == model.Purpose);

                // ölü kodları hariç bırak
                if(otpCode is null || otpCode.AttemptCount >= 3 || otpCode.ExpiredAt < DateTime.Now || otpCode.CanUsed == false)
                {
                    response.Status = Status.Default;
                    response.Message = "OTP kodunuz geçersiz veya süresi dolmuş olabilir. Lütfen yeni bir kod talep edin.";
                    return response;
                }

                // kullanıcının girdiği kodun hash'ini al
                var otpCodeHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(model.CodeHash)));

                if(otpCode.CodeHash != otpCodeHash)
                {
                    // yanlış kod denemesi
                    otpCode.AttemptCount += 1; // deneme sayısını artır
                    await _context.SaveChangesAsync(); // değişiklikleri kaydet
                    response.Status = Status.Default;
                    response.Message = $"OTP kodunuz yanlış. Kalan deneme hakkınız: {3 - otpCode.AttemptCount}";                    
                }
                else
                {
                    response.Status = Status.Success;
                    response.Message = "OTP doğrulaması başarılı.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/CheckOtpInDb ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
