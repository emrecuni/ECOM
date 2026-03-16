using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Api.Data.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string? Name { get; set; }
        public DateTime? AdditionTime { get; set; }

        // reverse navigation property
        public ICollection<Product> Products { get; set; } = [];
    }
}
