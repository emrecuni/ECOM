using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class ForgotPasswordRequestDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RePassword { get; set; } = null!;
    }
}