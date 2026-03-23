using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class EditCartRequestDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int Piece { get; set; }
        public bool Enable { get; set; }
    }
}
