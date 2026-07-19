using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs.Auth;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface IAuthApiClient
    {
        public Task<ApiResult<LoginResponseDto>?> TokenAsync(LoginRequestDto model, CancellationToken ct);
    }
}
