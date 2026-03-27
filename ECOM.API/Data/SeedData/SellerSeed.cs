using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class SellerSeed : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(
                new Seller { SellerId = 1, Name = "TechStore", CreatedAt = new DateTime(2023,5,5) },
                new Seller { SellerId = 2, Name = "ElektroMarket", CreatedAt = new DateTime(2023, 5, 5) },
                new Seller { SellerId = 3, Name = "DigiShop", CreatedAt = new DateTime(2023, 5, 5) }
            );
        }
    }
}
