using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class OtpRequestDto
    {
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? CodeHash { get; set; }
        public OtpPurpose Purpose { get; set; }
    }
}
