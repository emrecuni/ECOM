using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class ContactInfoResponseDto
    {
        public int CustomerId { get; set; }
        public string? NewPhone { get; set; }
        public string? NewEmail { get; set; }        
    }
}
