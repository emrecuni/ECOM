using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class SaveOtpRequestDto
    {
        public int VerificationId { get; set; }
        public string Email { get; set; } = null!;
        public string CodeHash { get; set; } = null!;
        public DateTime ExpiredAt { get; set; }
        public bool IsUsed { get; set; }
        public int AttemptCount { get; set; } = 0;
        public OtpPurpose Purpose { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
