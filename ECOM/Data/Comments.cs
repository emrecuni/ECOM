using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Comments
    {
        [Key]
        [Column("Id")]
        public int CommentID { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? Comment { get; set; }
        public string? ImagePath { get; set; }

    }
}
