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
                    ImagePath = "products/iphone15pro.jpg",
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
                    ImagePath = "products/s24ultra.jpg",
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
                    ImagePath = "products/xiaomi14tpro.jpg",
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
                    ImagePath = "products/macbookairm3.jpg",
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
                    ImagePath = "products/galaxybook4pro.jpg",
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
                    ImagePath = "products/samsungneqled65.jpg",
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
                    ImagePath = "products/lgoled c4.jpg",
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
                    ImagePath = "products/sonywh1000xm5.jpg",
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
                    ImagePath = "products/airpodspro2.jpg",
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
                    ImagePath = "products/xiaomipurifier4pro.jpg",
                    CreatedAt = new DateTime(2024, 6, 30)
                },
                new Product
                {
                    ProductId = 11,
                    BrandId = 8,
                    SupCategoryId = 7,
                    SubCategoryId = 8,
                    SellerId = 4,
                    Name = "Mavi Jake Slim Fit Jean",
                    Description = "Esnek denim kumaş, slim fit kesim ve koyu indigo yıkama ile günlük kullanıma uygun erkek jean.",
                    Price = 1799.99m,
                    Score = 4.5f,
                    ImagePath = "products/mavijakejean.jpg",
                    CreatedAt = new DateTime(2024, 3, 14)
                },
                new Product
                {
                    ProductId = 12,
                    BrandId = 7,
                    SupCategoryId = 7,
                    SubCategoryId = 8,
                    SellerId = 4,
                    Name = "Adidas Essentials 3-Stripes Sweatshirt",
                    Description = "Yumuşak pamuklu iç yüzey, klasik 3 şerit detayı ve rahat kesimli erkek sweatshirt.",
                    Price = 1499.99m,
                    Score = 4.4f,
                    ImagePath = "products/adidasessentialssweat.jpg",
                    CreatedAt = new DateTime(2024, 10, 8)
                },
                new Product
                {
                    ProductId = 13,
                    BrandId = 9,
                    SupCategoryId = 7,
                    SubCategoryId = 9,
                    SellerId = 4,
                    Name = "Zara Kuşaklı Trençkot",
                    Description = "Su itici kumaş, kruvaze önden kapanış ve bel kuşağı ile zamansız kadın trençkot.",
                    Price = 3299.99m,
                    Score = 4.6f,
                    ImagePath = "products/zaratrenckot.jpg",
                    CreatedAt = new DateTime(2024, 9, 2)
                },
                new Product
                {
                    ProductId = 14,
                    BrandId = 8,
                    SupCategoryId = 7,
                    SubCategoryId = 9,
                    SellerId = 4,
                    Name = "Mavi Serenay Yüksek Bel Jean",
                    Description = "Yüksek bel, skinny kesim ve toparlayıcı esnek kumaş ile kadın jean.",
                    Price = 1699.99m,
                    Score = 4.3f,
                    ImagePath = "products/maviserenayjean.jpg",
                    CreatedAt = new DateTime(2024, 5, 6)
                },
                new Product
                {
                    ProductId = 15,
                    BrandId = 6,
                    SupCategoryId = 7,
                    SubCategoryId = 10,
                    SellerId = 4,
                    Name = "Nike Air Force 1 '07",
                    Description = "Deri üst yüzey, Air yastıklama teknolojisi ve ikonik tasarımıyla günlük spor ayakkabı.",
                    Price = 4299.99m,
                    Score = 4.8f,
                    ImagePath = "products/nikeairforce1.jpg",
                    CreatedAt = new DateTime(2024, 2, 27)
                },
                new Product
                {
                    ProductId = 16,
                    BrandId = 7,
                    SupCategoryId = 7,
                    SubCategoryId = 10,
                    SellerId = 4,
                    Name = "Adidas Ultraboost Light",
                    Description = "Hafif Boost ara taban, Primeknit üst yüzey ve Continental dış taban ile koşu ayakkabısı.",
                    Price = 6499.99m,
                    Score = 4.7f,
                    ImagePath = "products/adidasultraboostlight.jpg",
                    CreatedAt = new DateTime(2024, 4, 19)
                },
                new Product
                {
                    ProductId = 17,
                    BrandId = 10,
                    SupCategoryId = 11,
                    SubCategoryId = 12,
                    SellerId = 5,
                    Name = "IKEA KALLAX Raf Ünitesi",
                    Description = "4x4 bölmeli, çok yönlü kullanılabilen beyaz raf ünitesi; dikey veya yatay yerleştirilebilir.",
                    Price = 4999.99m,
                    Score = 4.6f,
                    ImagePath = "products/ikeakallax.jpg",
                    CreatedAt = new DateTime(2024, 1, 11)
                },
                new Product
                {
                    ProductId = 18,
                    BrandId = 10,
                    SupCategoryId = 11,
                    SubCategoryId = 12,
                    SellerId = 5,
                    Name = "IKEA POÄNG Koltuk",
                    Description = "Huş kaplama esnek çerçeve ve yıkanabilir minder kılıfı ile ergonomik dinlenme koltuğu.",
                    Price = 5999.99m,
                    Score = 4.5f,
                    ImagePath = "products/ikeapoang.jpg",
                    CreatedAt = new DateTime(2024, 7, 3)
                },
                new Product
                {
                    ProductId = 19,
                    BrandId = 11,
                    SupCategoryId = 11,
                    SubCategoryId = 13,
                    SellerId = 5,
                    Name = "Karaca Hatır Türk Kahvesi Makinesi",
                    Description = "Köpük sensörü, sesli uyarı ve 5 fincan kapasitesi ile pratik Türk kahvesi makinesi.",
                    Price = 2499.99m,
                    Score = 4.6f,
                    ImagePath = "products/karacahatir.jpg",
                    CreatedAt = new DateTime(2024, 8, 21)
                },
                new Product
                {
                    ProductId = 20,
                    BrandId = 12,
                    SupCategoryId = 11,
                    SubCategoryId = 13,
                    SellerId = 5,
                    Name = "Tefal Ingenio 13 Parça Tencere Seti",
                    Description = "Çıkarılabilir saplar, Titanium yapışmaz kaplama ve indüksiyon uyumlu tabanlı istiflenebilir set.",
                    Price = 6999.99m,
                    Score = 4.7f,
                    ImagePath = "products/tefalingenio.jpg",
                    CreatedAt = new DateTime(2024, 11, 2)
                },
                new Product
                {
                    ProductId = 21,
                    BrandId = 2,
                    SupCategoryId = 1,
                    SubCategoryId = 2,
                    SellerId = 1,
                    Name = "Apple iPhone 18 Pro",
                    Description = "Yeni nesil A serisi çip, gelişmiş Pro kamera sistemi ve dayanıklı gövdesiyle Apple'ın en yeni Pro modeli. Mavi renk seçeneği.",
                    Price = 89999.99m,
                    Score = 4.8f,
                    ImagePath = "products/iphone18pro.jpg",
                    CreatedAt = new DateTime(2026, 9, 18)
                }
            );
        }
    }
}
