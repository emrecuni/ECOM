using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.MVC.OldFiles.Data
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }

        // reverse navigation property
        public ICollection<Product> Products { get; set; } = [];
    }
}
