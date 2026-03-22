using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public string? Name { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
