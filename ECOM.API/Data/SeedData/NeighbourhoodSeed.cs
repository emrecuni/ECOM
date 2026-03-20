using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class NeighbourhoodSeed : IEntityTypeConfiguration<Neighbourhood>
    {
        public void Configure(EntityTypeBuilder<Neighbourhood> builder)
        {
            builder.HasData(
                new Neighbourhood { NeighbourhoodId = 1, DistrictId = 1, Name = "Moda" },
                new Neighbourhood { NeighbourhoodId = 2, DistrictId = 1, Name = "Göztepe" },
                new Neighbourhood { NeighbourhoodId = 3, DistrictId = 2, Name = "Levent" },
                new Neighbourhood { NeighbourhoodId = 4, DistrictId = 2, Name = "Etiler" },
                new Neighbourhood { NeighbourhoodId = 5, DistrictId = 4, Name = "Kızılay" }
            );
        }
    }
}
