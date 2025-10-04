using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class OrderHistory
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int? CardId { get; set; }
        public int SellerId { get; set; }
        public int? CartId { get; set; }
        public int? Piece { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
       
        // navigation property 
        public Product Product { get; set; } = null!;
        public Customers Customer { get; set; } = null!;
        public Card Card { get; set; } = null!;
        public Seller Seller { get; set; } = null!;
    }
}
