using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class AddressCreateDto
    {
        public int AddressId { get; set; }
        public string? AddressName { get; set; }
        public string? Address { get; set; }
        public int? City { get; set; }
        public int? District { get; set; }
        public int? Neighbourhood { get; set; }
        public ReceiverDto? Receiver { get; set; } 
    }
}
