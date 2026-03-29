using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class ChangePasswordRequestDto
    {
        public int CustomerId { get; set; }
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ReNewPassword { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
    }
}
