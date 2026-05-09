using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class OrderSeed : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasData(
                new OrderHistory
                {
                    OrderId = 1,
                    ProductId = 1,       // iPhone 15 Pro
                    CustomerId = 1,
                    CardId = 1,
                    SellerId = 1,        // TechStore
                    CartId = null,       // direkt satın alınmış
                    Piece = 1,
                    TotalPrice = 54999.99m,
                    OrderDate = new DateTime(2024, 9, 20),
                    DeliveryDate = new DateTime(2024, 9, 23)
                },
                new OrderHistory
                {
                    OrderId = 2,
                    ProductId = 8,       // Sony WH-1000XM5
                    CustomerId = 1,
                    CardId = 1,
                    SellerId = 2,        // ElektroMarket
                    CartId = null,
                    Piece = 1,
                    TotalPrice = 9999.99m,
                    OrderDate = new DateTime(2024, 10, 5),
                    DeliveryDate = new DateTime(2024, 10, 8)
                },
                new OrderHistory
                {
                    OrderId = 3,
                    ProductId = 4,       // MacBook Air M3
                    CustomerId = 2,
                    CardId = 2,
                    SellerId = 1,        // TechStore
                    CartId = 4,          // sepetten sipariş verilmiş
                    Piece = 1,
                    TotalPrice = 40499.99m,    // kuponlu fiyat
                    OrderDate = new DateTime(2024, 10, 12),
                    DeliveryDate = new DateTime(2024, 10, 16)
                },
                new OrderHistory
                {
                    OrderId = 4,
                    ProductId = 9,       // AirPods Pro 2
                    CustomerId = 2,
                    CardId = 2,
                    SellerId = 3,        // DigiShop
                    CartId = null,
                    Piece = 2,
                    TotalPrice = 16999.98m,    // 8499.99 * 2
                    OrderDate = new DateTime(2024, 10, 18),
                    DeliveryDate = new DateTime(2024, 10, 21)
                },
                new OrderHistory
                {
                    OrderId = 5,
                    ProductId = 7,       // LG OLED C4 55"
                    CustomerId = 3,
                    CardId = 3,
                    SellerId = 1,        // TechStore
                    CartId = 5,          // sepetten sipariş verilmiş
                    Piece = 1,
                    TotalPrice = 29999.99m,
                    OrderDate = new DateTime(2024, 10, 25),
                    DeliveryDate = new DateTime(2024, 10, 29)
                },
                new OrderHistory
                {
                    OrderId = 6,
                    ProductId = 3,       // Xiaomi 14T Pro
                    CustomerId = 3,
                    CardId = 3,
                    SellerId = 3,        // DigiShop
                    CartId = null,
                    Piece = 1,
                    TotalPrice = 24999.99m,
                    OrderDate = new DateTime(2024, 11, 1),
                    DeliveryDate = new DateTime(2024, 11, 4)
                },
                new OrderHistory
                {
                    OrderId = 7,
                    ProductId = 6,       // Samsung Neo QLED 65"
                    CustomerId = 1,
                    CardId = 1,
                    SellerId = 3,        // DigiShop
                    CartId = null,
                    Piece = 1,
                    TotalPrice = 34999.99m,
                    OrderDate = new DateTime(2024, 11, 7),
                    DeliveryDate = null  // henüz teslim edilmemiş
                },
                new OrderHistory
                {
                    OrderId = 8,
                    ProductId = 10,      // Xiaomi Air Purifier
                    CustomerId = 2,
                    CardId = 2,
                    SellerId = 1,        // TechStore
                    CartId = 8,          // sepetten sipariş verilmiş
                    Piece = 2,
                    TotalPrice = 6299.98m,     // kuponlu fiyat
                    OrderDate = new DateTime(2024, 11, 8),
                    DeliveryDate = null  // henüz teslim edilmemiş
                }
            );
        }
    }
}
