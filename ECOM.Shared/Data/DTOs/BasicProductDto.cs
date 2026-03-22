using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Entities;

namespace ECOM.Shared.Data.DTOs
{
    public class BasicProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public float? Score { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<Favorites> Favorites { get; set; } = [];
    }
}
