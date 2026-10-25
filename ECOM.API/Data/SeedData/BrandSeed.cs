using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class BrandSeed : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { BrandId = 1, Name = "Samsung", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 2, Name = "Apple", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 3, Name = "Sony", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 4, Name = "LG", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 5, Name = "Xiaomi", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 6, Name = "Nike", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 7, Name = "Adidas", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 8, Name = "Mavi", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 9, Name = "Zara", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 10, Name = "IKEA", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 11, Name = "Karaca", CreatedAt = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 12, Name = "Tefal", CreatedAt = new DateTime(2023, 5, 5) }
            );
        }
    }
}
