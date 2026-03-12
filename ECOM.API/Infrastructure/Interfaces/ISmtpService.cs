using ECOM.Shared.Data.DTOs;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface ISmtpService
    {
        public Task<Response<SmtpResponseDto>> SendEmailAsync(SmtpRequestDto model);
    }
}
