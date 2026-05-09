using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Auth
{
    public class CheckCustomerDto
    {
        public int? CustomerId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
