using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Smtp;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface IAuthApiClient
    {
        public Task<ApiResult<LoginResponseDto>?> TokenAsync(LoginRequestDto model, CancellationToken ct);

        public Task<ApiResult<SmtpResponseDto>?> SendOtpAsync(OtpRequestDto model,CancellationToken ct);
        public Task<ApiResult<OtpResponseDto>?> CheckOtpAsync(OtpRequestDto model,CancellationToken ct);
        public Task<ApiResult<RegisterResponseDto>?> RegisterAsync(RegisterRequestDto model,CancellationToken ct);
        public Task<ApiResult<ForgotPasswordResponseDto>?> ForgotPassword(ForgotPasswordRequestDto model,CancellationToken ct);
    }
}
