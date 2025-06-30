using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Favorites
    {
        [Key]
        [Column("Id")]
        public int FavoriteId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime AdditionTime { get; set; }
    }
}
