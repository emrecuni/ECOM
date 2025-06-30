using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Cart
    {
        [Key]
        [Column("Id")]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public int DCouponId { get; set; }
        public int Piece { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Enable { get; set; }
    }
}
