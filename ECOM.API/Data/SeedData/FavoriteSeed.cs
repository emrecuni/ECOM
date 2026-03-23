using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class FavoriteSeed : IEntityTypeConfiguration<Favorites>
    {
        public void Configure(EntityTypeBuilder<Favorites> builder)
        {
            builder.HasData(
                new Favorites
                {
                    FavoriteId = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    AdditionTime = new DateTime(2024, 9, 15)
                },
                new Favorites
                {
                    FavoriteId = 2,
                    CustomerId = 1,
                    ProductId = 2,
                    AdditionTime = new DateTime(2024, 9, 15)
                },
                new Favorites
                {
                    FavoriteId = 3,
                    CustomerId = 2,
                    ProductId = 3,
                    AdditionTime = new DateTime(2024, 9, 15)
                },
                new Favorites
                {
                    FavoriteId = 4,
                    CustomerId = 1,
                    ProductId = 4,
                    AdditionTime = new DateTime(2024, 9, 15)
                }
            );
        }
    }
}
