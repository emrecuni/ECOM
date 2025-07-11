﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string? CardNo { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public DateTime? AdditionTime { get; set; }

        //navigation property
        public Customers Customer { get; set; } = null!;

        // reverse navigation property
        public ICollection<OrderHistory> Orders { get; set; } = [];
    }
}
