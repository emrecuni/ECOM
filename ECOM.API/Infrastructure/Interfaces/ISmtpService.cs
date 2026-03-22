using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Smtp;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface ISmtpService
    {
        public Task<Response<SmtpResponseDto>> SendEmailAsync(SmtpRequestDto model);
    }
}
