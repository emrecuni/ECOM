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
                entity.Property(a => a.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired();
                entity.Property(a => a.AddressName).HasColumnName("ADDRESS_NAME").IsRequired(false);
                entity.Property(a => a.Address).HasColumnName("ADDRESS").IsRequired(false);
                entity.Property(a => a.CityId).HasColumnName("CITY_ID").IsRequired();
                entity.Property(a => a.DistrictId).HasColumnName("DISTRICT_ID").IsRequired();
                entity.Property(a => a.NeighbourhoodId).HasColumnName("NEIGHBOURHOOD_ID").IsRequired();
                entity.Property(a => a.ReceiverId).HasColumnName("RECEIVER_ID").IsRequired();
                entity.Property(a => a.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);

                //customer relation
                entity.HasOne(a => a.Customer)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // restrict ilişkili veri silinmeden ana veri silinmez

                //receiver relation
                entity.HasOne(a => a.Receiver)
                .WithMany(c => c.ReceiverAddresses)
                .HasForeignKey(a => a.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

                // city relation
                entity.HasOne(a => a.City)
                .WithMany(c => c.CityOfAddresses)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

                //district relation
                entity.HasOne(a => a.District)
                .WithMany(d => d.DistrictOfAddresses)
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

                entity.Property(b => b.BrandID).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(b => b.Name).HasColumnName("NAME").IsRequired();
                entity.Property(b => b.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("CARDS");

                entity.HasKey(c => c.CardId);

                entity.Property(c => c.CardId).HasColumnName("ID");
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired();
                entity.Property(c => c.CardNo).HasColumnName("CARD_NO").IsRequired();
                entity.Property(c => c.CVV).HasColumnName("CVV").IsRequired();
                entity.Property(c => c.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);

                entity.HasOne(cc => cc.Customer)
                .WithMany(c => c.Cards)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("CART");

                entity.HasKey(c => c.CartId);

                entity.Property(c => c.CartId).HasColumnName("ID");
                entity.Property(c => c.ProductId).HasColumnName("PRODUCT_ID").IsRequired();
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired();
                entity.Property(c => c.SellerId).HasColumnName("SELLER_ID").IsRequired();
                entity.Property(c => c.DCouponId).HasColumnName("DCOUPON_ID").IsRequired(false);
                entity.Property(c => c.Piece).HasColumnName("PIECE").IsRequired(false);
                entity.Property(c => c.TotalPrice).HasColumnName("TOTAL_PRICE").IsRequired();
                entity.Property(c => c.Enable).HasColumnName("ENABLE").IsRequired(false);

                // product relation
                entity.HasOne(c => c.Product)
                .WithMany(p => p.Carts)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                // customer relation
                entity.HasOne(cc => cc.Customer)
                .WithMany(c => c.Carts)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                // seller relation
                entity.HasOne(c => c.Seller)
                .WithMany(s => s.Carts)
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

                // coupon relation
                entity.HasOne(c => c.Coupon)
                .WithMany(dc => dc.Carts)
                .HasForeignKey(c => c.DCouponId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.HasKey(c => c.CityId);

                entity.Property(c => c.CityId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasColumnName("NAME").IsRequired(false);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.HasKey(c => c.CommentId);

                entity.Property(c => c.CommentId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(c => c.ProductId).HasColumnName("PRODUCT_ID").IsRequired(true);
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired(true);
                entity.Property(c => c.Comment).HasColumnName("COMMENT").IsRequired(false);
                entity.Property(c => c.Score).HasColumnName("SCORE").IsRequired(false);
                entity.Property(c => c.ImagePath).HasColumnName("IMAGE_PATH").IsRequired(false);

                // product relation
                entity.HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                // customer relation
                entity.HasOne(cc => cc.Customer)
                .WithMany(c => c.Comments)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.CustomerId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasColumnName("NAME").IsRequired();
                entity.Property(c => c.Surname).HasColumnName("SURNAME").IsRequired();
                entity.Property(c => c.Email).HasColumnName("EMAIL").IsRequired(false);
                entity.Property(c => c.Phone).HasColumnName("PHONE").IsRequired(false);
                entity.Property(c => c.Password).HasColumnName("PASSWORD").IsRequired();
                entity.Property(c => c.Gender).HasColumnName("GENDER").IsRequired();
                entity.Property(c => c.IsCustomer).HasColumnName("IS_CUSTOMER").IsRequired(false);
                entity.Property(c => c.BirthDate).HasColumnName("BIRTHDATE").IsRequired(false);
                entity.Property(c => c.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);
            });

            modelBuilder.Entity<DCoupon>(entity =>
            {
                entity.ToTable("D_COUPONS");

                entity.HasKey(c => c.DCouponId);

                entity.Property(c => c.DCouponId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(c => c.SCouponId).HasColumnName("S_COUPON_ID").IsRequired();
                entity.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired();
                entity.Property(c => c.Enable).HasColumnName("ENABLE").IsRequired(false);
                entity.Property(c => c.DefinitionDate).HasColumnName("DEFINITION_DATE").IsRequired(false);

                // scoupon relation
                entity.HasOne(dc => dc.Coupon)
                .WithMany(sc => sc.Coupons)
                .HasForeignKey(dc => dc.SCouponId)
                .OnDelete(DeleteBehavior.Restrict);

                // customer relation
                entity.HasOne(dc => dc.Customer)
                .WithMany(c => c.Coupons)
                .HasForeignKey(dc => dc.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("DISTRICT");

                entity.HasKey(d => d.DistrictId);

                entity.Property(d => d.DistrictId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(d => d.CityId).HasColumnName("CITY_ID").IsRequired();
                entity.Property(d => d.Name).HasColumnName("NAME").IsRequired(false);

                // city relation
                entity.HasOne(d => d.City)
                .WithMany(c => c.Districts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.ToTable("FAVORITES");

                entity.HasKey(f => f.FavoriteId);

                entity.Property(f => f.FavoriteId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(f => f.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired();
                entity.Property(f => f.ProductId).HasColumnName("PRODUCT_ID").IsRequired();
                entity.Property(f => f.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);

                // customer relation
                entity.HasOne(f => f.Customer)
                .WithMany(c => c.Favorites)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                // product relation
                entity.HasOne(f => f.Product)
                .WithMany(p => p.Favorites)
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("LOG");

                entity.HasKey(l => l.LogId);

                entity.Property(l => l.LogId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(l => l.TableName).HasColumnName("TABLE_NAME").IsRequired(false);
                entity.Property(l => l.OldValue).HasColumnName("OLD_VALUE").IsRequired(false);
                entity.Property(l => l.NewValue).HasColumnName("NEW_VALUE").IsRequired(false);
                entity.Property(l => l.ProcessType).HasColumnName("PROCESS_TYPE").IsRequired(false);
                entity.Property(l => l.ProcessTime).HasColumnName("PROCESS_TIME").IsRequired(false);
            });

            modelBuilder.Entity<Neighbourhood>(entity =>
            {
                entity.ToTable("NEIGHBOURHOODS");

                entity.HasKey(n => n.NeighbourhoodId);

                entity.Property(n => n.NeighbourhoodId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(n => n.CityId).HasColumnName("CITY_ID").IsRequired();
                entity.Property(n => n.DistrictId).HasColumnName("DISTRICT_ID").IsRequired();
                entity.Property(n => n.Name).HasColumnName("NAME").IsRequired(false);

                // city relation 
                entity.HasOne(n => n.City)
                .WithMany(c => c.Neighbourhoods)
                .HasForeignKey(n => n.CityId)
                .OnDelete(DeleteBehavior.Restrict);

                // district relation
                entity.HasOne(n => n.District)
                .WithMany(d => d.Neighbourhoods)
                .HasForeignKey(n => n.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.ToTable("ORDER_HISTORY");

                entity.HasKey(o => o.OrderId);

                entity.Property(o => o.OrderId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(o => o.ProductId).HasColumnName("PRODUCT_ID").IsRequired();
                entity.Property(o => o.CustomerId).HasColumnName("CUSTOMER_ID").IsRequired();
                entity.Property(o => o.CardId).HasColumnName("CARD_ID").IsRequired();
                entity.Property(o => o.SellerId).HasColumnName("SELLER_ID").IsRequired();
                entity.Property(o => o.Piece).HasColumnName("PIECE").IsRequired(false);
                entity.Property(o => o.OrderDate).HasColumnName("ORDER_DATE").IsRequired(false);
                entity.Property(o => o.DeliveryDate).HasColumnName("DELIVERY_DATE").IsRequired(false);

                // product relation
                entity.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                // customer relation
                entity.HasOne(o => o.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                // card relation
                entity.HasOne(o => o.Card)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.CardId)
                .OnDelete(DeleteBehavior.Restrict);

                // seller relation
                entity.HasOne(o => o.Seller)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.ProductId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnName("NAME").IsRequired();
                entity.Property(p => p.BrandId).HasColumnName("BRAND_ID").IsRequired();
                entity.Property(p => p.Description).HasColumnName("DESCRIPTION").IsRequired(false);
                entity.Property(p => p.SupCategoryId).HasColumnName("SUP_CATEGORY_ID").IsRequired();
                entity.Property(p => p.SubCategoryId).HasColumnName("SUB_CATEGORY_ID").IsRequired();
                entity.Property(p => p.Price).HasColumnName("PRICE").IsRequired(false);
                entity.Property(p => p.SellerId).HasColumnName("SELLER_ID").IsRequired();
                entity.Property(p => p.Score).HasColumnName("SCORE").IsRequired(false);
                entity.Property(p => p.ImagePath).HasColumnName("IMAGE_PATH").IsRequired(false);
                entity.Property(p => p.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);

                entity.HasOne(p => p.Brand)
                .WithMany(b=> b.Products)
                .HasForeignKey(p =>p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.SupCategory)
                .WithMany(c => c.SupCategories)
                .HasForeignKey(p => p.SupCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.SubCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.ToTable("PRODUCT_CATEGORIES");

                entity.HasKey(p => p.CategoryId);

                entity.Property(p => p.CategoryId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnName("NAME").IsRequired();
                entity.Property(p => p.Type).HasColumnName("TYPE").IsRequired();
                entity.Property(p => p.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);
            });

            modelBuilder.Entity<SCoupon>(entity =>
            {
                entity.ToTable("S_COUPONS");

                entity.HasKey(c => c.SCouponId);

                entity.Property(c => c.SCouponId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(c => c.Amount).HasColumnName("AMOUNT").IsRequired(false);
                entity.Property(c => c.LowerLimit).HasColumnName("LOWER_LIMIT").IsRequired(false);
                entity.Property(c => c.ValidityDate).HasColumnName("VALIDITY_DATE").IsRequired(false);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("SELLERS");

                entity.HasKey(s => s.SellerId);

                entity.Property(s => s.SellerId).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(s => s.Name).HasColumnName("NAME").IsRequired(false);
                entity.Property(s => s.Score).HasColumnName("SCORE").IsRequired(false);
                entity.Property(s => s.AdditionTime).HasColumnName("ADDITION_TIME").IsRequired(false);
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
