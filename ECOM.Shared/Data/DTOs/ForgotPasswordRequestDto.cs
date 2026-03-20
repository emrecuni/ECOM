using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class ForgotPasswordRequestDto
    {
        public string? Email { get; set; }
        public string? OtpCode { get; set; }
    }
}
