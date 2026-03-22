using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Enums;

namespace ECOM.Shared.Data.DTOs.Auth
{
    public class OtpResponseDto
    {
        public string Email { get; set; } = null!;
        public int AttemptCount { get; set; }
        public OtpPurpose Purpose { get; set; }
    }
}
