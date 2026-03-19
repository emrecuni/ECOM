using ECOM.Shared.Data.DTOs;

namespace ECOM.API.Data.Entities
{
    public class EmailVerification
    {
        public int VerificationId { get; set; }
        public string Email { get; set; } = null!;
        public string CodeHash { get; set; } = null!;
        public DateTime ExpiredAt { get; set; }
        public bool IsUsed { get; set; }
        public bool CanUsed { get; set; }
        public int AttemptCount { get; set; } = 0;
        public OtpPurpose Purpose { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
