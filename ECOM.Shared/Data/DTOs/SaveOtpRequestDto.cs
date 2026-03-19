using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class SaveOtpRequestDto
    {
        public string Email { get; set; } = null!;
        public string CodeHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public OtpPurpose Purpose { get; set; }
    }
}
