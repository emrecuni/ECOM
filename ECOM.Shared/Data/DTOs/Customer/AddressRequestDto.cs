using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Entities;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class AddressRequestDto
    {
        public int CustomerId { get; set; }
        public AddressCreateDto? Address { get; set; }
    }
}