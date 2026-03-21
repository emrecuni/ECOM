using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class ForgotPasswordResponseDto
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
    }
}
