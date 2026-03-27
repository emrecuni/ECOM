using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class CommentSeed : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasData(
                new Comments
                {
                    CommentId = 1,
                    ProductId = 1,
                    CustomerId = 1,
                    Comment = "Great product! Highly recommend.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 1, 15)
                },
                new Comments
                {
                    CommentId = 2,
                    ProductId = 1,
                    CustomerId = 2,
                    Comment = "Not bad! Recommend.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 2, 15)
                },
                new Comments
                {
                    CommentId = 3,
                    ProductId = 1,
                    CustomerId = 4,
                    Comment = "Wonderful! Highly recommend.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 3, 15)
                },
                new Comments
                {
                    CommentId = 4,
                    ProductId = 3,
                    CustomerId = 3,
                    Comment = "Recommend.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 2, 25)
                }
            );
        }
    }
}
