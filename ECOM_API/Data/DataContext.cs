using ECOM_API.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECOM_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }

        public DbSet<Customers> Customers => Set<Customers>();
    }
}
