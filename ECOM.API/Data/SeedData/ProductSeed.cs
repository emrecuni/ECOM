using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    BrandId = 2,
                    SupCategoryId = 1,
                    SubCategoryId = 2,
                    SellerId = 1,
                    Name = "Apple iPhone 15 Pro",
                    Description = "A17 Pro çip, 48MP kamera sistemi ve titanyum tasarım ile güçlü bir akıllı telefon.",
                    Price = 54999.99m,
                    Score = 4.8f,
                    ImagePath = "/images/products/iphone15pro.jpg",
                    CreatedAt = new DateTime(2024, 9, 15)
                },
                new Product
                {
                    ProductId = 2,
                    BrandId = 1,
                    SupCategoryId = 1,
                    SubCategoryId = 2,
                    SellerId = 2,
                    Name = "Samsung Galaxy S24 Ultra",
                    Description = "Snapdragon 8 Gen 3 işlemci, 200MP kamera ve dahili S Pen ile üst segment deneyimi.",
                    Price = 49999.99m,
                    Score = 4.7f,
                    ImagePath = "/images/products/s24ultra.jpg",
                    CreatedAt = new DateTime(2024, 1, 20)
                },
                new Product
                {
                    ProductId = 3,
                    BrandId = 5,
                    SupCategoryId = 1,
                    SubCategoryId = 2,
                    SellerId = 3,
                    Name = "Xiaomi 14T Pro",
                    Description = "Leica kamera ortaklığı, 5000mAh batarya ve 144Hz AMOLED ekran.",
                    Price = 24999.99m,
                    Score = 4.5f,
                    ImagePath = "/images/products/xiaomi14tpro.jpg",
                    CreatedAt = new DateTime(2024, 10, 3)
                },
                new Product
                {
                    ProductId = 4,
                    BrandId = 2,
                    SupCategoryId = 1,
                    SubCategoryId = 3,
                    SellerId = 1,
                    Name = "Apple MacBook Air M3",
                    Description = "M3 çip, 13.6 inç Liquid Retina ekran ve 18 saate kadar pil ömrü.",
                    Price = 44999.99m,
                    Score = 4.9f,
                    ImagePath = "/images/products/macbookairm3.jpg",
                    CreatedAt = new DateTime(2024, 3, 8)
                },
                new Product
                {
                    ProductId = 5,
                    BrandId = 1,
                    SupCategoryId = 1,
                    SubCategoryId = 3,
                    SellerId = 2,
                    Name = "Samsung Galaxy Book4 Pro",
                    Description = "Intel Core Ultra 7 işlemci, 14 inç AMOLED ekran ve hafif alüminyum gövde.",
                    Price = 38999.99m,
                    Score = 4.4f,
                    ImagePath = "/images/products/galaxybook4pro.jpg",
                    CreatedAt = new DateTime(2024, 4, 12)
                },
                new Product
                {
                    ProductId = 6,
                    BrandId = 1,
                    SupCategoryId = 1,
                    SubCategoryId = 4,
                    SellerId = 3,
                    Name = "Samsung Neo QLED 4K 65\"",
                    Description = "Neo Quantum işlemci, Mini LED arka aydınlatma ve Dolby Atmos ses desteği.",
                    Price = 34999.99m,
                    Score = 4.6f,
                    ImagePath = "/images/products/samsungneqled65.jpg",
                    CreatedAt = new DateTime(2024, 2, 18)
                },
                new Product
                {
                    ProductId = 7,
                    BrandId = 4,
                    SupCategoryId = 1,
                    SubCategoryId = 4,
                    SellerId = 1,
                    Name = "LG OLED C4 55\"",
                    Description = "OLED evo panel, α9 AI işlemci ve webOS 24 ile sinema kalitesi deneyim.",
                    Price = 29999.99m,
                    Score = 4.8f,
                    ImagePath = "/images/products/lgoled c4.jpg",
                    CreatedAt = new DateTime(2024, 5, 22)
                },
                new Product
                {
                    ProductId = 8,
                    BrandId = 3,
                    SupCategoryId = 1,
                    SubCategoryId = 5,
                    SellerId = 2,
                    Name = "Sony WH-1000XM5",
                    Description = "Sektörün en iyi gürültü engelleme teknolojisi, 30 saat pil ömrü ve katlanabilir tasarım.",
                    Price = 9999.99m,
                    Score = 4.9f,
                    ImagePath = "/images/products/sonywh1000xm5.jpg",
                    CreatedAt = new DateTime(2023, 11, 5)
                },
                new Product
                {
                    ProductId = 9,
                    BrandId = 2,
                    SupCategoryId = 1,
                    SubCategoryId = 5,
                    SellerId = 3,
                    Name = "Apple AirPods Pro 2",
                    Description = "Aktif gürültü engelleme, Adaptif Ses ve H2 çip ile mükemmel ses deneyimi.",
                    Price = 8499.99m,
                    Score = 4.7f,
                    ImagePath = "/images/products/airpodspro2.jpg",
                    CreatedAt = new DateTime(2023, 9, 23)
                },
                new Product
                {
                    ProductId = 10,
                    BrandId = 5,
                    SupCategoryId = 1,
                    SubCategoryId = 6,
                    SellerId = 1,
                    Name = "Xiaomi Smart Air Purifier 4 Pro",
                    Description = "OLED ekran, HEPA filtre ve Mi Home uygulaması ile akıllı hava temizleyici.",
                    Price = 3499.99m,
                    Score = 4.3f,
                    ImagePath = "/images/products/xiaomipurifier4pro.jpg",
                    CreatedAt = new DateTime(2024, 6, 30)
                }
            );
        }
    }
}
