using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string? AddressName { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int ReceiverId { get; set; } // customer'da kayıtlı değilse kayıt et
        public DateTime AdditionTime { get; set; }
        public Customers Receiver { get; set; } = null!;
        public Customers Customer { get; set; } = null!;
        public City City { get; set; } = null!;
        public District District { get; set;} = null!;
        public Neighbourhood Neighbourhood { get; set; } = null!;        
    }
}
