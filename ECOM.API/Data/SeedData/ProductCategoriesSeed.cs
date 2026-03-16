using ECOM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class ProductCategoriesSeed : IEntityTypeConfiguration<ProductCategories>
    {
        public void Configure(EntityTypeBuilder<ProductCategories> builder)
        {
            builder.HasData(
                new ProductCategories { CategoryId = 1, Name = "Elektronik", AdditionTime = new DateTime(2023, 5, 5) },         // SupCategory
                new ProductCategories { CategoryId = 2, Name = "Telefon", AdditionTime = new DateTime(2023, 5, 5) },            // SubCategory
                new ProductCategories { CategoryId = 3, Name = "Bilgisayar", AdditionTime = new DateTime(2023, 5, 5) },         // SubCategory
                new ProductCategories { CategoryId = 4, Name = "Televizyon", AdditionTime = new DateTime(2023, 5, 5) },         // SubCategory
                new ProductCategories { CategoryId = 5, Name = "Ses Sistemleri", AdditionTime = new DateTime(2023, 5, 5) },     // SubCategory
                new ProductCategories { CategoryId = 6, Name = "Küçük Ev Aletleri", AdditionTime = new DateTime(2023, 5, 5) }   // SubCategory
            );
        }
    }
}
