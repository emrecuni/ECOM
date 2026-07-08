using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.MVC.OldFiles.Data
{
    public class Favorites
    {
        [Key]
        public int FavoriteId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Customers Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
