using ECOM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class CitySeed : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City { CityId = 1, Name = "İstanbul" },
                new City { CityId = 2, Name = "Ankara" },
                new City { CityId = 3, Name = "İzmir" }
            );
        }
    }
}
