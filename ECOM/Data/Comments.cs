using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? Comment { get; set; }
        public int? Score { get; set; }
        public string? ImagePath { get; set; }

        // navigation property
        public Product Product { get; set; } = null!;
        public Customers Customer { get; set; } = null!;

    }
}
