using ECOM.Api.Data.Entities;
using ECOM.API.Data;
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

                if(customer is  null || !EncryptionHelper.VerifyPassword(model.Password, customer.Password!))
                    return null;
                
                return customer;
			}
			catch (Exception ex)
			{
                _logger.LogError($"LoginService/LoginAsync Error => {ex}");
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

        public async Task<Response<SmtpResponseDto>> SendVerifyEmail(SmtpRequestDto model)
        {
            return await _smtpService.SendEmailAsync(model);
        }

        public Task SaveOtpCode(SaveOtpRequestDto model)
        {
            throw new NotImplementedException();
        }
    }
}
