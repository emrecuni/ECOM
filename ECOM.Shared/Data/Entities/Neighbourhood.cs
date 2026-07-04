using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Shared.Data.Entities
{
    public class Neighbourhood
    {
        [Key]
        public int NeighbourhoodId { get; set; }
        public int DistrictId { get; set; }
        public string? Name { get; set; }
        public string? ZipCode { get; set; }

        // navigation property
        public District District { get; set; } = null!;

        // reverse navigation property
        public ICollection<Addresses> NeighbourhoodOfAddresss { get; set; } = [];
    }
}
