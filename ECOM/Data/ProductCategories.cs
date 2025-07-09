using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class ProductCategories
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public bool Type { get; set; }
        public DateTime AdditionTime { get; set; }

        //reverse navigation property

        public ICollection<Product> SupCategories { get; set; } = [];
        public ICollection<Product> SubCategories { get; set; } = [];
    }
}
