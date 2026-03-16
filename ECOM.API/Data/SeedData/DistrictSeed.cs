using ECOM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class DistrictSeed : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasData(
                new District { DistrictId = 1, CityId = 1, Name = "Kadıköy" },
                new District { DistrictId = 2, CityId = 1, Name = "Beşiktaş" },
                new District { DistrictId = 3, CityId = 1, Name = "Üsküdar" },
                new District { DistrictId = 4, CityId = 2, Name = "Çankaya" },
                new District { DistrictId = 5, CityId = 3, Name = "Konak" }
            );
        }
    }
}
