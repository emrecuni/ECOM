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

                entity.Property(a => a.AddressId).HasColumnName("ID").ValueGeneratedOnAdd(); // ValueGeneratedOnAdd => auto-increment
                entity.Property(a => a.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(a => a.AddressName).HasColumnName("ADDRESS_NAME");
                entity.Property(a => a.Address).HasColumnName("ADDRESS");
                entity.Property(a => a.CityId).HasColumnName("CITY_ID");
                entity.Property(a => a.DistrictId).HasColumnName("DISTRICT_ID");
                entity.Property(a => a.NeighbourhoodId).HasColumnName("NEIGHBOURHOOD_ID");
                entity.Property(a => a.ReceiverId).HasColumnName("RECEIVER_ID");
                entity.Property(a => a.AdditionTime).HasColumnName("ADDITION_TIME");

                //customer relation
                entity.HasOne(a => a.Customer)
                .WithMany(c => c.CustomerAdress)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                //receiver relation
                entity.HasOne(a => a.Receiver)
                .WithMany(c => c.ReceiverAddress)
                .HasForeignKey(a => a.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

                // city relation
                entity.HasOne(a => a.City)
                .WithMany(c => c.CityOfAddress)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

                //district relation
                entity.HasOne(a => a.District)
                .WithMany(d => d.DistrictOfAddress)
                .HasForeignKey(a => a.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Neighbourhood)
                .WithMany(n => n.NeighbourhoodOfAddresss)
                .HasForeignKey(a => a.NeighbourhoodId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRANDS");

                entity.HasKey(b => b.BrandID);

                entity.Property(b => b.BrandID).HasColumnName("ID");
                entity.Property(b => b.Name).HasColumnName("NAME");
                entity.Property(b => b.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("CARDS");

                entity.HasKey(c => c.CardId);

                entity.Property(c => c.CardId).HasColumnName("ID");
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(c => c.CardNo).HasColumnName("CARD_NO");
                entity.Property(c => c.CVV).HasColumnName("CVV");
                entity.Property(c => c.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("CART");

                entity.HasKey(c => c.CartId);

                entity.Property(c => c.CartId).HasColumnName("ID");
                entity.Property(c => c.ProductId).HasColumnName("PRODUCT_ID");
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(c => c.SellerId).HasColumnName("SELLER_ID");
                entity.Property(c => c.DCouponId).HasColumnName("DCOUPON_ID");
                entity.Property(c => c.Piece).HasColumnName("PIECE");
                entity.Property(c => c.TotalPrice).HasColumnName("TOTAL_PRICE");
                entity.Property(c => c.Enable).HasColumnName("ENABLE");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.HasKey(c => c.CityId);

                entity.Property(c => c.CityId).HasColumnName("ID");
                entity.Property(c => c.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.HasKey(c => c.CommentId);

                entity.Property(c => c.CommentId).HasColumnName("ID");
                entity.Property(c => c.ProductId).HasColumnName("PRODUCT_ID");
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(c => c.Comment).HasColumnName("COMMENT");
                entity.Property(c => c.ImagePath).HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.CustomerId).HasColumnName("ID");
                entity.Property(c => c.Name).HasColumnName("NAME");
                entity.Property(c => c.Surname).HasColumnName("SURNAME");
                entity.Property(c => c.Email).HasColumnName("EMAIL");
                entity.Property(c => c.Phone).HasColumnName("PHONE");
                entity.Property(c => c.Password).HasColumnName("PASSWORD");
                entity.Property(c => c.Gender).HasColumnName("GENDER");
                entity.Property(c => c.BirthDate).HasColumnName("BIRTHDATE");
                entity.Property(c => c.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<DCoupon>(entity =>
            {
                entity.ToTable("D_COUPONS");

                entity.HasKey(c => c.DCouponId);

                entity.Property(c => c.DCouponId).HasColumnName("ID");
                entity.Property(c => c.SCouponId).HasColumnName("S_COUPON_ID");
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(c => c.Enable).HasColumnName("ENABLE");
                entity.Property(c => c.DefinitionDate).HasColumnName("DEFINITION_DATE");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("DISTRICT");

                entity.HasKey(d => d.DistrictId);

                entity.Property(d => d.DistrictId).HasColumnName("ID");
                entity.Property(d => d.CityId).HasColumnName("CITY_ID");
                entity.Property(d => d.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.ToTable("FAVORITES");

                entity.HasKey(f => f.FavoriteId);

                entity.Property(f => f.FavoriteId).HasColumnName("ID");
                entity.Property(f => f.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(f => f.ProductId).HasColumnName("PRODUCT_ID");
                entity.Property(f => f.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("LOG");

                entity.HasKey(l => l.LogId);

                entity.Property(l => l.LogId).HasColumnName("ID");
                entity.Property(l => l.TableName).HasColumnName("TABLE_NAME");
                entity.Property(l => l.OldValue).HasColumnName("OLD_VALUE");
                entity.Property(l => l.NewValue).HasColumnName("NEW_VALUE");
                entity.Property(l => l.ProcessType).HasColumnName("PROCESS_TYPE");
                entity.Property(l => l.ProcessTime).HasColumnName("PROCESS_TIME");
            });

            modelBuilder.Entity<Neighbourhood>(entity =>
            {
                entity.ToTable("NEIGHBOURHOODS");

                entity.HasKey(n => n.NeighbourhoodId);

                entity.Property(n => n.NeighbourhoodId).HasColumnName("ID");
                entity.Property(n => n.CityId).HasColumnName("CITY_ID");
                entity.Property(n => n.DistrictId).HasColumnName("DISTRICT_ID");
                entity.Property(n => n.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.ToTable("ORDER_HISTORY");

                entity.HasKey(o => o.OrderId);

                entity.Property(o => o.OrderId).HasColumnName("ID");
                entity.Property(o => o.ProductId).HasColumnName("PRODUCT_ID");
                entity.Property(o => o.CustomerId).HasColumnName("CUSTOMER_ID");
                entity.Property(o => o.CardId).HasColumnName("CARD_ID");
                entity.Property(o => o.SellerId).HasColumnName("SELLER_ID");
                entity.Property(o => o.Piece).HasColumnName("PIECE");
                entity.Property(o => o.OrderDate).HasColumnName("ORDER_DATE");
                entity.Property(o => o.DeliveryDate).HasColumnName("DELIVERY_DATE");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.ProductId).HasColumnName("ID");
                entity.Property(p => p.Name).HasColumnName("NAME");
                entity.Property(p => p.BrandId).HasColumnName("BRAND_ID");
                entity.Property(p => p.Description).HasColumnName("DESCRIPTION");
                entity.Property(p => p.SupCategoryId).HasColumnName("SUP_CATEGORY_ID");
                entity.Property(p => p.SubCategoryId).HasColumnName("SUB_CATEGORY_ID");
                entity.Property(p => p.Price).HasColumnName("PRICE");
                entity.Property(p => p.SellerId).HasColumnName("SELLER_ID");
                entity.Property(p => p.Score).HasColumnName("SCORE");
                entity.Property(p => p.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.ToTable("PRODUCT_CATEGORIES");

                entity.HasKey(p => p.CategoryId);

                entity.Property(p => p.CategoryId).HasColumnName("ID");
                entity.Property(p => p.Name).HasColumnName("NAME");
                entity.Property(p => p.Type).HasColumnName("TYPE");
                entity.Property(p => p.AdditionTime).HasColumnName("ADDITION_TIME");
            });

            modelBuilder.Entity<SCoupon>(entity =>
            {
                entity.ToTable("S_COUPONS");

                entity.HasKey(c => c.SCouponId);

                entity.Property(c => c.SCouponId).HasColumnName("ID");
                entity.Property(c => c.Amount).HasColumnName("AMOUNT");
                entity.Property(c => c.LowerLimit).HasColumnName("LOWER_LIMIT");
                entity.Property(c => c.ValidityDate).HasColumnName("VALIDITY_DATE");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("SELLERS");

                entity.HasKey(s => s.SellerId);

                entity.Property(s => s.SellerId).HasColumnName("ID");
                entity.Property(s => s.Name).HasColumnName("NAME");
                entity.Property(s => s.Score).HasColumnName("SCORE");
                entity.Property(s => s.AdditionTime).HasColumnName("ADDITION_TIME");
            });
        }

        public DbSet<Addresses> Addresses => Set<Addresses>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Comments> Comments => Set<Comments>();
        public DbSet<Customers> Customers => Set<Customers>();
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
