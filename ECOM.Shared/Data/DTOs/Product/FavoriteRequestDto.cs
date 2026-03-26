using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class FavoriteRequestDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
