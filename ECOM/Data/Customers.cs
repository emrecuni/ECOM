using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public bool Gender { get; set; }
        public bool? IsCustomer { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AdditionTime { get; set; }

        // reverse navigation property
        public ICollection<Addresses> ReceiverAddresses { get; set; } = []; // new List<Addresses>()
        public ICollection<Addresses> CustomerAddresses { get; set; } = [];
        public ICollection<Card> Cards { get; set; } = [];
        public ICollection<Cart> Carts { get; set; } = [];
        public ICollection<DCoupon> Coupons { get; set; } = [];
        public ICollection<Favorites> Favorites { get; set; } = [];
        public ICollection<OrderHistory> Orders { get; set; } = [];
        public ICollection<Comments> Comments { get; set; } = [];
    }
}
