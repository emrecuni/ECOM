using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class AddressResponseDto
    {
        public int CustomerId { get; set; }
        public List<AddressDetailDto>? Addresses { get; set; }
    }
}
