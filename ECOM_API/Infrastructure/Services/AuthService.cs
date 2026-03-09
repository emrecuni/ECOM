using ECOM_API.Data;
using ECOM_API.Data.Entity;
using ECOM_API.Data.Models;
using ECOM_API.Helpers;
using ECOM_API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECOM_API.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly ILogger<AuthService> _logger;

        public AuthService(DataContext context, ILogger<AuthService> logger)
        {
            _context = context;
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
    }
}
