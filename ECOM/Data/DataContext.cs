using Microsoft.EntityFrameworkCore;

namespace ECOM.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // kolon adları için mapping yapar
            // [column("id")]'den daha profesyonel ve kompleks projeler için daha okunabilir
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("ADDRESSES");

                entity.HasKey(a => a.AddressId);

                entity.Property(a => a.AddressId).HasColumnName("ID");
                entity.Property(a => a.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(a => a.AddressName).HasColumnName("ADDRESS_NAME");
                entity.Property(a => a.Address).HasColumnName("ADDRESS");
                entity.Property(a => a.CityId).HasColumnName("CITY_ID");
                entity.Property(a => a.DistrictId).HasColumnName("DISTRICT_ID");
                entity.Property(a => a.NeighbourhoodId).HasColumnName("NEIGHBOURHOOD_ID");
                entity.Property(a => a.ReceiverId).HasColumnName("RECEIVER_ID");
                entity.Property(a => a.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRANDS");

            })
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
