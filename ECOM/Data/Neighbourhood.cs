using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Neighbourhood
    {
        [Key]
        public int NeighbourhoodId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string? Name { get; set; }

        public ICollection<Addresses> NeighbourhoodOfAddresss { get; set; } = [];
    }
}
