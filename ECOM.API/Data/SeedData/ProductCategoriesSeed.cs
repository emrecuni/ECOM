using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class ProductCategoriesSeed : IEntityTypeConfiguration<ProductCategories>
    {
        public void Configure(EntityTypeBuilder<ProductCategories> builder)
        {
            builder.HasData(
                new ProductCategories { CategoryId = 1, Name = "Elektronik", CreatedAt = new DateTime(2023, 5, 5) },         // SupCategory
                new ProductCategories { CategoryId = 2, Name = "Telefon", CreatedAt = new DateTime(2023, 5, 5) },            // SubCategory
                new ProductCategories { CategoryId = 3, Name = "Bilgisayar", CreatedAt = new DateTime(2023, 5, 5) },         // SubCategory
                new ProductCategories { CategoryId = 4, Name = "Televizyon", CreatedAt = new DateTime(2023, 5, 5) },         // SubCategory
                new ProductCategories { CategoryId = 5, Name = "Ses Sistemleri", CreatedAt = new DateTime(2023, 5, 5) },     // SubCategory
                new ProductCategories { CategoryId = 6, Name = "Küçük Ev Aletleri", CreatedAt = new DateTime(2023, 5, 5) },  // SubCategory
                new ProductCategories { CategoryId = 7, Name = "Moda", CreatedAt = new DateTime(2023, 5, 5) },               // SupCategory
                new ProductCategories { CategoryId = 8, Name = "Erkek Giyim", CreatedAt = new DateTime(2023, 5, 5) },        // SubCategory
                new ProductCategories { CategoryId = 9, Name = "Kadın Giyim", CreatedAt = new DateTime(2023, 5, 5) },        // SubCategory
                new ProductCategories { CategoryId = 10, Name = "Ayakkabı", CreatedAt = new DateTime(2023, 5, 5) },          // SubCategory
                new ProductCategories { CategoryId = 11, Name = "Ev & Yaşam", CreatedAt = new DateTime(2023, 5, 5) },        // SupCategory
                new ProductCategories { CategoryId = 12, Name = "Mobilya", CreatedAt = new DateTime(2023, 5, 5) },           // SubCategory
                new ProductCategories { CategoryId = 13, Name = "Mutfak Gereçleri", CreatedAt = new DateTime(2023, 5, 5) },  // SubCategory
                new ProductCategories { CategoryId = 14, Name = "Spor", CreatedAt = new DateTime(2023, 5, 5) },              // SupCategory
                new ProductCategories { CategoryId = 15, Name = "Futbol Ekipmanları", CreatedAt = new DateTime(2023, 5, 5) }, // SubCategory
                new ProductCategories { CategoryId = 16, Name = "Bilgisayar Bileşenleri", CreatedAt = new DateTime(2023, 5, 5) }, // SubCategory
                new ProductCategories { CategoryId = 17, Name = "Tablet", CreatedAt = new DateTime(2023, 5, 5) }             // SubCategory
            );
        }
    }
}
