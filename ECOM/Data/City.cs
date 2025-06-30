using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class City
    {
        [Key]
        [Column("Id")]
        public int CityId { get; set; }
        public string? Name { get; set; }
    }
}
