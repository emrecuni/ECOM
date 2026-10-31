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
                    Score = (5 + 3 + 5) / 3f,
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
                    Score = (5 + 4 + 5) / 3f,
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
                    Score = (5 + 4 + 4) / 3f,
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
                    Score = (5 + 5 + 4) / 3f,
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
                    Score = (4 + 4) / 2f,
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
                    Score = (5 + 4 + 4) / 3f,
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
                    Score = (5 + 5) / 2f,
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
                    Score = (5 + 5 + 4) / 3f,
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
                    Score = (5 + 4 + 4) / 3f,
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
                    Score = (4 + 3) / 2f,
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
                    Score = (5 + 4 + 4) / 3f,
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
                    Score = (4 + 4 + 5) / 3f,
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
                    Score = (5 + 4) / 2f,
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
                    Score = (4 + 3 + 4) / 3f,
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
                    Score = (5 + 5 + 5) / 3f,
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
                    Score = (5 + 4 + 5) / 3f,
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
                    Score = (5 + 4) / 2f,
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
                    Score = (4 + 5 + 4) / 3f,
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
                    Score = (5 + 4 + 5) / 3f,
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
                    Score = (5 + 5 + 4) / 3f,
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
                    Score = (5 + 5) / 2f,
                    ImagePath = "products/iphone18pro.jpg",
                    CreatedAt = new DateTime(2026, 9, 18)
                },
                new Product
                {
                    ProductId = 22,
                    BrandId = 13,
                    SupCategoryId = 1,
                    SubCategoryId = 16,
                    SellerId = 3,
                    Name = "AMD Ryzen 5 5600X",
                    Description = "6 çekirdek 12 izlek, 4.6 GHz boost hızı ve 65W TDP ile oyun ve günlük kullanım için verimli masaüstü işlemci.",
                    Price = 5499.99m,
                    Score = (5 + 5 + 4) / 3f,
                    ImagePath = "products/AMD Ryzen 5 5600X.jpg",
                    CreatedAt = new DateTime(2025, 2, 10)
                },
                new Product
                {
                    ProductId = 23,
                    BrandId = 14,
                    SupCategoryId = 1,
                    SubCategoryId = 16,
                    SellerId = 1,
                    Name = "ASUS TUF Gaming B550M-E WiFi Anakart",
                    Description = "AM4 soket, PCIe 4.0, Wi-Fi 6 ve 2.5Gb Ethernet desteğiyle dayanıklı mATX anakart.",
                    Price = 4299.99m,
                    Score = (4 + 4 + 5) / 3f,
                    ImagePath = "products/asus-tuf-gaming-b550m-e-wifi-1.png",
                    CreatedAt = new DateTime(2025, 2, 12)
                },
                new Product
                {
                    ProductId = 24,
                    BrandId = 15,
                    SupCategoryId = 1,
                    SubCategoryId = 16,
                    SellerId = 2,
                    Name = "MSI GeForce GTX 1660 Ventus XS 6GB",
                    Description = "6GB GDDR5 bellek ve çift fanlı Ventus soğutmayla 1080p oyunlar için ekran kartı.",
                    Price = 8999.99m,
                    Score = (4 + 3 + 4) / 3f,
                    ImagePath = "products/gtx 1660.jpg",
                    CreatedAt = new DateTime(2025, 3, 1)
                },
                new Product
                {
                    ProductId = 25,
                    BrandId = 15,
                    SupCategoryId = 1,
                    SubCategoryId = 16,
                    SellerId = 3,
                    Name = "MSI MAG Forge 100M Kasa",
                    Description = "Temperli cam yan panel, 2 adet ARGB fan ve geniş hava akışı sunan Mid-Tower oyuncu kasası.",
                    Price = 2499.99m,
                    Score = (4 + 5) / 2f,
                    ImagePath = "products/msi 100m.jpg",
                    CreatedAt = new DateTime(2025, 3, 5)
                },
                new Product
                {
                    ProductId = 26,
                    BrandId = 18,
                    SupCategoryId = 1,
                    SubCategoryId = 16,
                    SellerId = 1,
                    Name = "Team Group T-Force Vulcan Z 16GB DDR4 3200MHz",
                    Description = "2x8GB kit, alüminyum soğutucu ve düşük gecikme değerleriyle masaüstü bellek.",
                    Price = 1399.99m,
                    Score = (5 + 4 + 4) / 3f,
                    ImagePath = "products/team t-force.jpg",
                    CreatedAt = new DateTime(2025, 3, 8)
                },
                new Product
                {
                    ProductId = 27,
                    BrandId = 14,
                    SupCategoryId = 1,
                    SubCategoryId = 3,
                    SellerId = 2,
                    Name = "ASUS TUF Gaming VG24VQR 23.6\" Kavisli Monitör",
                    Description = "165Hz yenileme hızı, 1ms MPRT ve FreeSync Premium destekli Full HD kavisli oyuncu monitörü.",
                    Price = 5999.99m,
                    Score = (5 + 4 + 5) / 3f,
                    ImagePath = "products/tuf vg24vqr.jpg",
                    CreatedAt = new DateTime(2025, 3, 15)
                },
                new Product
                {
                    ProductId = 28,
                    BrandId = 19,
                    SupCategoryId = 1,
                    SubCategoryId = 16,
                    SellerId = 2,
                    Name = "XFX Speedster SWFT 210 Radeon RX 6600 8GB",
                    Description = "8GB GDDR6 bellek ve RDNA 2 mimarisiyle 1080p oyunlarda yüksek performans.",
                    Price = 9499.99m,
                    Score = (4 + 4) / 2f,
                    ImagePath = "products/xfx rx6600.jpg",
                    CreatedAt = new DateTime(2025, 4, 2)
                },
                new Product
                {
                    ProductId = 29,
                    BrandId = 5,
                    SupCategoryId = 1,
                    SubCategoryId = 17,
                    SellerId = 3,
                    Name = "Xiaomi Pad 7",
                    Description = "11.2 inç 144Hz 3.2K ekran, Snapdragon 7+ Gen 3 işlemci ve 8850 mAh batarya.",
                    Price = 15999.99m,
                    Score = (5 + 4 + 4) / 3f,
                    ImagePath = "products/xiaomi-pad-7.jpg",
                    CreatedAt = new DateTime(2025, 4, 20)
                },
                new Product
                {
                    ProductId = 30,
                    BrandId = 6,
                    SupCategoryId = 14,
                    SubCategoryId = 15,
                    SellerId = 6,
                    Name = "Nike Mercurial Superfly Krampon",
                    Description = "Hafif üst yüzey ve çorap bilekli tasarımıyla hız odaklı profesyonel futbol kramponu.",
                    Price = 7499.99m,
                    Score = (5 + 5 + 4) / 3f,
                    ImagePath = "products/Nike Superfly.jpg",
                    CreatedAt = new DateTime(2025, 5, 3)
                },
                new Product
                {
                    ProductId = 31,
                    BrandId = 16,
                    SupCategoryId = 14,
                    SubCategoryId = 15,
                    SellerId = 6,
                    Name = "Puma Future Krampon",
                    Description = "Ayarlanabilir FUZIONFIT+ bant sistemiyle ayağı saran, top kontrolü odaklı krampon.",
                    Price = 5299.99m,
                    Score = (4 + 4 + 3) / 3f,
                    ImagePath = "products/Puma Future.jpg",
                    CreatedAt = new DateTime(2025, 5, 6)
                },
                new Product
                {
                    ProductId = 32,
                    BrandId = 16,
                    SupCategoryId = 14,
                    SubCategoryId = 15,
                    SellerId = 6,
                    Name = "Puma Ultra Krampon",
                    Description = "Ultra hafif yapısı ve hızlı çıkış sağlayan tabanıyla süratli oyuncular için krampon.",
                    Price = 4799.99m,
                    Score = (4 + 5) / 2f,
                    ImagePath = "products/Puma Ultra.jpg",
                    CreatedAt = new DateTime(2025, 5, 9)
                },
                new Product
                {
                    ProductId = 33,
                    BrandId = 17,
                    SupCategoryId = 14,
                    SubCategoryId = 15,
                    SellerId = 6,
                    Name = "Reusch Attrakt Kaleci Eldiveni",
                    Description = "Yüksek tutuş sağlayan Grip lateks avuç içi ve esnek bilek bandıyla maç eldiveni.",
                    Price = 2299.99m,
                    Score = (5 + 4 + 4) / 3f,
                    ImagePath = "products/reusch.jpg",
                    CreatedAt = new DateTime(2025, 5, 12)
                },
                new Product
                {
                    ProductId = 34,
                    BrandId = 17,
                    SupCategoryId = 14,
                    SubCategoryId = 15,
                    SellerId = 6,
                    Name = "Reusch Argos Pro M1 Kaleci Eldiveni",
                    Description = "Parmak koruma çubuklu yapısı ve dayanıklı lateksiyle antrenman ve maç eldiveni.",
                    Price = 1899.99m,
                    Score = (3 + 4 + 3) / 3f,
                    ImagePath = "products/reusch(2).jpg",
                    CreatedAt = new DateTime(2025, 5, 15)
                },
                new Product
                {
                    ProductId = 35,
                    BrandId = 1,
                    SupCategoryId = 1,
                    SubCategoryId = 17,
                    SellerId = 2,
                    Name = "Samsung Galaxy Tab S9 FE",
                    Description = "10.9 inç ekran, S Pen desteği ve IP68 suya dayanıklılık sunan tablet.",
                    Price = 12999.99m,
                    Score = (4 + 4 + 5) / 3f,
                    ImagePath = "products/galaxytabs9fe.jpg",
                    CreatedAt = new DateTime(2025, 6, 1)
                },
                new Product
                {
                    ProductId = 36,
                    BrandId = 2,
                    SupCategoryId = 1,
                    SubCategoryId = 17,
                    SellerId = 1,
                    Name = "Apple iPad Air M2",
                    Description = "M2 çip, 11 inç Liquid Retina ekran ve Apple Pencil Pro desteğiyle güçlü tablet.",
                    Price = 27999.99m,
                    Score = (5 + 5 + 5) / 3f,
                    ImagePath = "products/ipadairm2.jpg",
                    CreatedAt = new DateTime(2025, 6, 4)
                },
                new Product
                {
                    ProductId = 37,
                    BrandId = 3,
                    SupCategoryId = 1,
                    SubCategoryId = 4,
                    SellerId = 2,
                    Name = "Sony Bravia 7 55\" Mini LED TV",
                    Description = "Mini LED aydınlatma, XR işlemci ve Google TV ile parlak ve canlı görüntü.",
                    Price = 44999.99m,
                    Score = (5 + 4) / 2f,
                    ImagePath = "products/sonybravia7.jpg",
                    CreatedAt = new DateTime(2025, 6, 10)
                },
                new Product
                {
                    ProductId = 38,
                    BrandId = 4,
                    SupCategoryId = 1,
                    SubCategoryId = 5,
                    SellerId = 3,
                    Name = "LG XBOOM Go XG8T Bluetooth Hoparlör",
                    Description = "IP67 dayanıklılık, 15 saat pil ömrü ve güçlü bas sunan taşınabilir hoparlör.",
                    Price = 6499.99m,
                    Score = (4 + 3 + 4) / 3f,
                    ImagePath = "products/lgxboomxg8t.jpg",
                    CreatedAt = new DateTime(2025, 6, 15)
                },
                new Product
                {
                    ProductId = 39,
                    BrandId = 5,
                    SupCategoryId = 1,
                    SubCategoryId = 6,
                    SellerId = 3,
                    Name = "Xiaomi Robot Vacuum S10",
                    Description = "Lazer navigasyon, 4000Pa emiş gücü ve paspas özelliğiyle akıllı robot süpürge.",
                    Price = 8999.99m,
                    Score = (5 + 4 + 4) / 3f,
                    ImagePath = "products/xiaomirobots10.jpg",
                    CreatedAt = new DateTime(2025, 7, 1)
                },
                new Product
                {
                    ProductId = 40,
                    BrandId = 6,
                    SupCategoryId = 7,
                    SubCategoryId = 8,
                    SellerId = 4,
                    Name = "Nike Dri-FIT Koşu Tişörtü",
                    Description = "Teri hızla uzaklaştıran Dri-FIT kumaş ve hafif yapısıyla erkek koşu tişörtü.",
                    Price = 1199.99m,
                    Score = (4 + 4) / 2f,
                    ImagePath = "products/nikedrifittshirt.jpg",
                    CreatedAt = new DateTime(2025, 7, 5)
                },
                new Product
                {
                    ProductId = 41,
                    BrandId = 9,
                    SupCategoryId = 7,
                    SubCategoryId = 9,
                    SellerId = 4,
                    Name = "Zara Saten Midi Elbise",
                    Description = "Akışkan saten kumaş, V yaka ve ince askılı midi boy kadın elbise.",
                    Price = 1899.99m,
                    Score = (5 + 3 + 4) / 3f,
                    ImagePath = "products/zarasatenelbise.jpg",
                    CreatedAt = new DateTime(2025, 7, 10)
                },
                new Product
                {
                    ProductId = 42,
                    BrandId = 8,
                    SupCategoryId = 7,
                    SubCategoryId = 9,
                    SellerId = 4,
                    Name = "Mavi Kapüşonlu Kadın Sweatshirt",
                    Description = "Yumuşak pamuklu içi şardonlu kumaş ve rahat kesimli kapüşonlu sweatshirt.",
                    Price = 999.99m,
                    Score = (4 + 4 + 4) / 3f,
                    ImagePath = "products/mavikapusonlusweat.jpg",
                    CreatedAt = new DateTime(2025, 7, 15)
                },
                new Product
                {
                    ProductId = 43,
                    BrandId = 10,
                    SupCategoryId = 11,
                    SubCategoryId = 12,
                    SellerId = 5,
                    Name = "IKEA MALM Çalışma Masası",
                    Description = "Çekmeceli, sade tasarımlı ve kablo düzenleme bölmeli çalışma masası.",
                    Price = 4499.99m,
                    Score = (4 + 5 + 4) / 3f,
                    ImagePath = "products/ikeamalmmasa.jpg",
                    CreatedAt = new DateTime(2025, 8, 1)
                },
                new Product
                {
                    ProductId = 44,
                    BrandId = 11,
                    SupCategoryId = 11,
                    SubCategoryId = 13,
                    SellerId = 5,
                    Name = "Karaca Bio Diamond 3'lü Tava Seti",
                    Description = "Elmas katkılı yapışmaz kaplama ve tüm ocaklarla uyumlu tabanlı tava seti.",
                    Price = 2799.99m,
                    Score = (5 + 4) / 2f,
                    ImagePath = "products/karacabiodiamond.jpg",
                    CreatedAt = new DateTime(2025, 8, 5)
                },
                new Product
                {
                    ProductId = 45,
                    BrandId = 12,
                    SupCategoryId = 1,
                    SubCategoryId = 6,
                    SellerId = 5,
                    Name = "Tefal Easy Fry XXL Airfryer",
                    Description = "5.6 litre kapasite, 8 otomatik program ve yağsız pişirme sunan fritöz.",
                    Price = 4999.99m,
                    Score = (5 + 5 + 4) / 3f,
                    ImagePath = "products/tefaleasyfry.jpg",
                    CreatedAt = new DateTime(2025, 8, 10)
                }
            );
        }
    }
}
