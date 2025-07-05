using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Neighbourhood
    {
        [Key]
        [Column("Id")]
        public int NeighbourhoodId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string? Name { get; set; }
    }
}
