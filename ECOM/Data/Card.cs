using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Card
    {
        [Key]
        [Column("Id")]
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string? CardNo { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public DateTime AdditionTime { get; set; }
    }
}
