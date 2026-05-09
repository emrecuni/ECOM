using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class AddressRequestDto
    {
        public int CustomerId { get; set; }
        public AddressDto? Address { get; set; }
    }
}
