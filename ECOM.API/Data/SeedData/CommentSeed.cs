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
                    CustomerId = 3,
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
                },
                new Comments
                {
                    CommentId = 5,
                    ProductId = 2,
                    CustomerId = 1,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 10)
                },
                new Comments
                {
                    CommentId = 6,
                    ProductId = 2,
                    CustomerId = 2,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 17)
                },
                new Comments
                {
                    CommentId = 7,
                    ProductId = 2,
                    CustomerId = 3,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 24)
                },
                new Comments
                {
                    CommentId = 8,
                    ProductId = 3,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 11)
                },
                new Comments
                {
                    CommentId = 9,
                    ProductId = 3,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 18)
                },
                new Comments
                {
                    CommentId = 10,
                    ProductId = 4,
                    CustomerId = 1,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 12)
                },
                new Comments
                {
                    CommentId = 11,
                    ProductId = 4,
                    CustomerId = 2,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 19)
                },
                new Comments
                {
                    CommentId = 12,
                    ProductId = 4,
                    CustomerId = 3,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 26)
                },
                new Comments
                {
                    CommentId = 13,
                    ProductId = 5,
                    CustomerId = 1,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 13)
                },
                new Comments
                {
                    CommentId = 14,
                    ProductId = 5,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 20)
                },
                new Comments
                {
                    CommentId = 15,
                    ProductId = 6,
                    CustomerId = 1,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 14)
                },
                new Comments
                {
                    CommentId = 16,
                    ProductId = 6,
                    CustomerId = 2,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 21)
                },
                new Comments
                {
                    CommentId = 17,
                    ProductId = 6,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 28)
                },
                new Comments
                {
                    CommentId = 18,
                    ProductId = 7,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 15)
                },
                new Comments
                {
                    CommentId = 19,
                    ProductId = 7,
                    CustomerId = 2,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 22)
                },
                new Comments
                {
                    CommentId = 20,
                    ProductId = 8,
                    CustomerId = 1,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 16)
                },
                new Comments
                {
                    CommentId = 21,
                    ProductId = 8,
                    CustomerId = 2,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 23)
                },
                new Comments
                {
                    CommentId = 22,
                    ProductId = 8,
                    CustomerId = 3,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 2)
                },
                new Comments
                {
                    CommentId = 23,
                    ProductId = 9,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 17)
                },
                new Comments
                {
                    CommentId = 24,
                    ProductId = 9,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 24)
                },
                new Comments
                {
                    CommentId = 25,
                    ProductId = 9,
                    CustomerId = 3,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 3)
                },
                new Comments
                {
                    CommentId = 26,
                    ProductId = 10,
                    CustomerId = 1,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 18)
                },
                new Comments
                {
                    CommentId = 27,
                    ProductId = 10,
                    CustomerId = 2,
                    Comment = "Ortalama bir ürün, idare eder.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 25)
                },
                new Comments
                {
                    CommentId = 28,
                    ProductId = 11,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 19)
                },
                new Comments
                {
                    CommentId = 29,
                    ProductId = 11,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 26)
                },
                new Comments
                {
                    CommentId = 30,
                    ProductId = 11,
                    CustomerId = 3,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 5)
                },
                new Comments
                {
                    CommentId = 31,
                    ProductId = 12,
                    CustomerId = 1,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 20)
                },
                new Comments
                {
                    CommentId = 32,
                    ProductId = 12,
                    CustomerId = 2,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 27)
                },
                new Comments
                {
                    CommentId = 33,
                    ProductId = 12,
                    CustomerId = 3,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 6)
                },
                new Comments
                {
                    CommentId = 34,
                    ProductId = 13,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 21)
                },
                new Comments
                {
                    CommentId = 35,
                    ProductId = 13,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 28)
                },
                new Comments
                {
                    CommentId = 36,
                    ProductId = 14,
                    CustomerId = 1,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 22)
                },
                new Comments
                {
                    CommentId = 37,
                    ProductId = 14,
                    CustomerId = 2,
                    Comment = "Fena değil ama daha iyisini beklerdim.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 1)
                },
                new Comments
                {
                    CommentId = 38,
                    ProductId = 14,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 8)
                },
                new Comments
                {
                    CommentId = 39,
                    ProductId = 15,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 23)
                },
                new Comments
                {
                    CommentId = 40,
                    ProductId = 15,
                    CustomerId = 2,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 2)
                },
                new Comments
                {
                    CommentId = 41,
                    ProductId = 15,
                    CustomerId = 3,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 9)
                },
                new Comments
                {
                    CommentId = 42,
                    ProductId = 16,
                    CustomerId = 1,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 24)
                },
                new Comments
                {
                    CommentId = 43,
                    ProductId = 16,
                    CustomerId = 2,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 3)
                },
                new Comments
                {
                    CommentId = 44,
                    ProductId = 16,
                    CustomerId = 3,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 10)
                },
                new Comments
                {
                    CommentId = 45,
                    ProductId = 17,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 25)
                },
                new Comments
                {
                    CommentId = 46,
                    ProductId = 17,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 4)
                },
                new Comments
                {
                    CommentId = 47,
                    ProductId = 18,
                    CustomerId = 1,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 26)
                },
                new Comments
                {
                    CommentId = 48,
                    ProductId = 18,
                    CustomerId = 2,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 5)
                },
                new Comments
                {
                    CommentId = 49,
                    ProductId = 18,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 12)
                },
                new Comments
                {
                    CommentId = 50,
                    ProductId = 19,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 27)
                },
                new Comments
                {
                    CommentId = 51,
                    ProductId = 19,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 6)
                },
                new Comments
                {
                    CommentId = 52,
                    ProductId = 19,
                    CustomerId = 3,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 13)
                },
                new Comments
                {
                    CommentId = 53,
                    ProductId = 20,
                    CustomerId = 1,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 28)
                },
                new Comments
                {
                    CommentId = 54,
                    ProductId = 20,
                    CustomerId = 2,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 7)
                },
                new Comments
                {
                    CommentId = 55,
                    ProductId = 20,
                    CustomerId = 3,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 14)
                },
                new Comments
                {
                    CommentId = 56,
                    ProductId = 21,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 1)
                },
                new Comments
                {
                    CommentId = 57,
                    ProductId = 21,
                    CustomerId = 2,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 8)
                },
                new Comments
                {
                    CommentId = 58,
                    ProductId = 22,
                    CustomerId = 1,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 2)
                },
                new Comments
                {
                    CommentId = 59,
                    ProductId = 22,
                    CustomerId = 2,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 9)
                },
                new Comments
                {
                    CommentId = 60,
                    ProductId = 22,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 16)
                },
                new Comments
                {
                    CommentId = 61,
                    ProductId = 23,
                    CustomerId = 1,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 3)
                },
                new Comments
                {
                    CommentId = 62,
                    ProductId = 23,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 10)
                },
                new Comments
                {
                    CommentId = 63,
                    ProductId = 23,
                    CustomerId = 3,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 17)
                },
                new Comments
                {
                    CommentId = 64,
                    ProductId = 24,
                    CustomerId = 1,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 4)
                },
                new Comments
                {
                    CommentId = 65,
                    ProductId = 24,
                    CustomerId = 2,
                    Comment = "Fiyatı biraz yüksek, performansı orta.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 11)
                },
                new Comments
                {
                    CommentId = 66,
                    ProductId = 24,
                    CustomerId = 3,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 18)
                },
                new Comments
                {
                    CommentId = 67,
                    ProductId = 25,
                    CustomerId = 1,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 5)
                },
                new Comments
                {
                    CommentId = 68,
                    ProductId = 25,
                    CustomerId = 2,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 12)
                },
                new Comments
                {
                    CommentId = 69,
                    ProductId = 26,
                    CustomerId = 1,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 6)
                },
                new Comments
                {
                    CommentId = 70,
                    ProductId = 26,
                    CustomerId = 2,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 13)
                },
                new Comments
                {
                    CommentId = 71,
                    ProductId = 26,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 20)
                },
                new Comments
                {
                    CommentId = 72,
                    ProductId = 27,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 7)
                },
                new Comments
                {
                    CommentId = 73,
                    ProductId = 27,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 14)
                },
                new Comments
                {
                    CommentId = 74,
                    ProductId = 27,
                    CustomerId = 3,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 21)
                },
                new Comments
                {
                    CommentId = 75,
                    ProductId = 28,
                    CustomerId = 1,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 8)
                },
                new Comments
                {
                    CommentId = 76,
                    ProductId = 28,
                    CustomerId = 2,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 15)
                },
                new Comments
                {
                    CommentId = 77,
                    ProductId = 29,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 9)
                },
                new Comments
                {
                    CommentId = 78,
                    ProductId = 29,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 16)
                },
                new Comments
                {
                    CommentId = 79,
                    ProductId = 29,
                    CustomerId = 3,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 23)
                },
                new Comments
                {
                    CommentId = 80,
                    ProductId = 30,
                    CustomerId = 1,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 10)
                },
                new Comments
                {
                    CommentId = 81,
                    ProductId = 30,
                    CustomerId = 2,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 17)
                },
                new Comments
                {
                    CommentId = 82,
                    ProductId = 30,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 24)
                },
                new Comments
                {
                    CommentId = 83,
                    ProductId = 31,
                    CustomerId = 1,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 11)
                },
                new Comments
                {
                    CommentId = 84,
                    ProductId = 31,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 18)
                },
                new Comments
                {
                    CommentId = 85,
                    ProductId = 31,
                    CustomerId = 3,
                    Comment = "Fena değil ama daha iyisini beklerdim.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 25)
                },
                new Comments
                {
                    CommentId = 86,
                    ProductId = 32,
                    CustomerId = 1,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 12)
                },
                new Comments
                {
                    CommentId = 87,
                    ProductId = 32,
                    CustomerId = 2,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 19)
                },
                new Comments
                {
                    CommentId = 88,
                    ProductId = 33,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 13)
                },
                new Comments
                {
                    CommentId = 89,
                    ProductId = 33,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 20)
                },
                new Comments
                {
                    CommentId = 90,
                    ProductId = 33,
                    CustomerId = 3,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 27)
                },
                new Comments
                {
                    CommentId = 91,
                    ProductId = 34,
                    CustomerId = 1,
                    Comment = "Fiyatı biraz yüksek, performansı orta.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 14)
                },
                new Comments
                {
                    CommentId = 92,
                    ProductId = 34,
                    CustomerId = 2,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 21)
                },
                new Comments
                {
                    CommentId = 93,
                    ProductId = 34,
                    CustomerId = 3,
                    Comment = "Fena değil ama daha iyisini beklerdim.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 28)
                },
                new Comments
                {
                    CommentId = 94,
                    ProductId = 35,
                    CustomerId = 1,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 15)
                },
                new Comments
                {
                    CommentId = 95,
                    ProductId = 35,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 22)
                },
                new Comments
                {
                    CommentId = 96,
                    ProductId = 35,
                    CustomerId = 3,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 1)
                },
                new Comments
                {
                    CommentId = 97,
                    ProductId = 36,
                    CustomerId = 1,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 16)
                },
                new Comments
                {
                    CommentId = 98,
                    ProductId = 36,
                    CustomerId = 2,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 23)
                },
                new Comments
                {
                    CommentId = 99,
                    ProductId = 36,
                    CustomerId = 3,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 2)
                },
                new Comments
                {
                    CommentId = 100,
                    ProductId = 37,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 17)
                },
                new Comments
                {
                    CommentId = 101,
                    ProductId = 37,
                    CustomerId = 2,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 24)
                },
                new Comments
                {
                    CommentId = 102,
                    ProductId = 38,
                    CustomerId = 1,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 18)
                },
                new Comments
                {
                    CommentId = 103,
                    ProductId = 38,
                    CustomerId = 2,
                    Comment = "Fena değil ama daha iyisini beklerdim.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 25)
                },
                new Comments
                {
                    CommentId = 104,
                    ProductId = 38,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 4)
                },
                new Comments
                {
                    CommentId = 105,
                    ProductId = 39,
                    CustomerId = 1,
                    Comment = "Harika bir ürün, kesinlikle tavsiye ederim.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 19)
                },
                new Comments
                {
                    CommentId = 106,
                    ProductId = 39,
                    CustomerId = 2,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 26)
                },
                new Comments
                {
                    CommentId = 107,
                    ProductId = 39,
                    CustomerId = 3,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 5)
                },
                new Comments
                {
                    CommentId = 108,
                    ProductId = 40,
                    CustomerId = 1,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 20)
                },
                new Comments
                {
                    CommentId = 109,
                    ProductId = 40,
                    CustomerId = 2,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 27)
                },
                new Comments
                {
                    CommentId = 110,
                    ProductId = 41,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 21)
                },
                new Comments
                {
                    CommentId = 111,
                    ProductId = 41,
                    CustomerId = 2,
                    Comment = "Fena değil ama daha iyisini beklerdim.",
                    Score = 3,
                    CreatedAt = new DateTime(2026, 10, 28)
                },
                new Comments
                {
                    CommentId = 112,
                    ProductId = 41,
                    CustomerId = 3,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 7)
                },
                new Comments
                {
                    CommentId = 113,
                    ProductId = 42,
                    CustomerId = 1,
                    Comment = "Beklediğim gibi çıktı, sorun yaşamadım.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 22)
                },
                new Comments
                {
                    CommentId = 114,
                    ProductId = 42,
                    CustomerId = 2,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 1)
                },
                new Comments
                {
                    CommentId = 115,
                    ProductId = 42,
                    CustomerId = 3,
                    Comment = "Genel olarak memnunum, küçük eksikleri var.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 8)
                },
                new Comments
                {
                    CommentId = 116,
                    ProductId = 43,
                    CustomerId = 1,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 23)
                },
                new Comments
                {
                    CommentId = 117,
                    ProductId = 43,
                    CustomerId = 2,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 2)
                },
                new Comments
                {
                    CommentId = 118,
                    ProductId = 43,
                    CustomerId = 3,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 9)
                },
                new Comments
                {
                    CommentId = 119,
                    ProductId = 44,
                    CustomerId = 1,
                    Comment = "Beklentimin çok üzerinde çıktı, çok memnunum.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 24)
                },
                new Comments
                {
                    CommentId = 120,
                    ProductId = 44,
                    CustomerId = 2,
                    Comment = "İyi bir ürün, tavsiye ederim.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 3)
                },
                new Comments
                {
                    CommentId = 121,
                    ProductId = 45,
                    CustomerId = 1,
                    Comment = "Kalitesi ve performansı mükemmel.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 25)
                },
                new Comments
                {
                    CommentId = 122,
                    ProductId = 45,
                    CustomerId = 2,
                    Comment = "Kargo hızlıydı, ürün kusursuz geldi.",
                    Score = 5,
                    CreatedAt = new DateTime(2026, 10, 4)
                },
                new Comments
                {
                    CommentId = 123,
                    ProductId = 45,
                    CustomerId = 3,
                    Comment = "Fiyatına göre gayet başarılı.",
                    Score = 4,
                    CreatedAt = new DateTime(2026, 10, 11)
                }
            );
        }
    }
}
