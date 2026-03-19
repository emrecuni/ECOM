using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class OtpResponseDto
    {
        public string Email { get; set; } = null!;
        public int AttemptCount { get; set; }
        public OtpPurpose Purpose { get; set; }
    }
}
