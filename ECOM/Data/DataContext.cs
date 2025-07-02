using Microsoft.EntityFrameworkCore;

namespace ECOM.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Addresses> Addresses => Set<Addresses>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Comments> Comments => Set<Comments>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<DCoupon> DCoupons => Set<DCoupon>();
        public DbSet<District> Districts => Set<District>();
        public DbSet<Favorites> Favorites => Set<Favorites>();
        public DbSet<Log> Log => Set<Log>();
        public DbSet<Neighbourhood> Neighbourhoods => Set<Neighbourhood>();
        public DbSet<OrderHistory> OrderHistory => Set<OrderHistory>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategories> ProductCategories => Set<ProductCategories>();
        public DbSet<SCoupon> SCoupons => Set<SCoupon>();
        public DbSet<Seller> Sellers => Set<Seller>();
    }
}
