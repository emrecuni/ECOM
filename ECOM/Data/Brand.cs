using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Brand
    {
        [Key]
        [Column("Id")]
        public int BrandID { get; set; }
        public string? Name { get; set; }
        public DateTime AdditionTime { get; set; }
    }
}
