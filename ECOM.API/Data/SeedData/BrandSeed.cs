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
                new Brand { BrandId = 1, Name = "Samsung", AdditionTime = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 2, Name = "Apple", AdditionTime = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 3, Name = "Sony", AdditionTime = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 4, Name = "LG", AdditionTime = new DateTime(2023, 5, 5) },
                new Brand { BrandId = 5, Name = "Xiaomi", AdditionTime = new DateTime(2023, 5, 5) }
            );
        }
    }
}
