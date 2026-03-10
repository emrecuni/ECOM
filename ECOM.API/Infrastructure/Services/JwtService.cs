using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECOM.Api.Data.Entities;
using ECOM.API.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ECOM.API.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<JwtService> _logger;

        public JwtService(IConfiguration config, ILogger<JwtService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public string GenerateToken(Customers customer)
        {
            try
            {
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                    new Claim(ClaimTypes.Name, customer.Name!),
                    new Claim(ClaimTypes.Email, customer.Email!),
                    new Claim(ClaimTypes.Role, customer.IsCustomer.ToString()!)
                };

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(
                        int.Parse(_config["Jwt:ExpireMinutes"]!)),
                    signingCredentials: new SigningCredentials(
                        key, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JwtService/GenerateToken Error ==> {ex}");
                return string.Empty;
            }
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"JwtService/ValidateToken Error ==> {ex}");
                return null;
            }
        }
    }
}
