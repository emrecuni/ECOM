using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class CartSeed : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasData(
                new Cart
                {
                    CartId = 1,
                    ProductId = 1,       // iPhone 15 Pro
                    CustomerId = 1,
                    SellerId = 1,        // TechStore                    
                    Piece = 1,
                    TotalPrice = 54999.99m,
                    Enable = true,
                    AdditionTime = new DateTime(2024, 11, 1)
                },
                new Cart
                {
                    CartId = 2,
                    ProductId = 3,       // Xiaomi 14T Pro
                    CustomerId = 1,
                    SellerId = 3,        // DigiShop
                    Piece = 1,
                    TotalPrice = 24999.99m,
                    Enable = true,
                    AdditionTime = new DateTime(2024, 11, 1)
                },
                new Cart
                {
                    CartId = 3,
                    ProductId = 8,       // Sony WH-1000XM5
                    CustomerId = 2,
                    SellerId = 2,        // ElektroMarket
                    Piece = 2,
                    TotalPrice = 19999.98m,    // 9999.99 * 2
                    Enable = true,
                    AdditionTime = new DateTime(2024, 11, 3)
                },
                new Cart
                {
                    CartId = 4,
                    ProductId = 4,       // MacBook Air M3
                    CustomerId = 2,
                    SellerId = 1,        // TechStore
                    Piece = 1,
                    TotalPrice = 40499.99m,    // indirimli fiyat
                    Enable = true,
                    AdditionTime = new DateTime(2024, 11, 5)
                },
                new Cart
                {
                    CartId = 5,
                    ProductId = 7,       // LG OLED C4 55"
                    CustomerId = 3,
                    SellerId = 1,        // TechStore
                    Piece = 1,
                    TotalPrice = 29999.99m,
                    Enable = true,
                    AdditionTime = new DateTime(2024, 11, 6)
                },
                new Cart
                {
                    CartId = 6,
                    ProductId = 9,       // AirPods Pro 2
                    CustomerId = 3,
                    SellerId = 3,        // DigiShop
                    Piece = 3,
                    TotalPrice = 25499.97m,    // 8499.99 * 3
                    Enable = true,
                    AdditionTime = new DateTime(2024, 11, 6)
                },
                new Cart
                {
                    CartId = 7,
                    ProductId = 2,       // Samsung Galaxy S24 Ultra
                    CustomerId = 1,
                    SellerId = 2,        // ElektroMarket
                    Piece = 1,
                    TotalPrice = 49999.99m,
                    Enable = false,      // sepetten kaldırılmış
                    AdditionTime = new DateTime(2024, 10, 28)
                },
                new Cart
                {
                    CartId = 8,
                    ProductId = 10,      // Xiaomi Air Purifier
                    CustomerId = 2,
                    SellerId = 1,        // TechStore
                    Piece = 2,
                    TotalPrice = 6299.98m,     // indirimli fiyat
                    Enable = false,      // sepetten kaldırılmış
                    AdditionTime = new DateTime(2024, 10, 30)
                }
            );
        }
    }
}
