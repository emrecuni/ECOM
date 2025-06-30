using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class District
    {
        [Key]
        [Column("Id")]
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
