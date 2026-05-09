using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class CardSeed : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(
               new Card
               {
                   CardId = 1,
                   CustomerId = 1,
                   CardNo = "4111111111111111",   // test kartı (Visa)
                   ExpirationDate = "12/26",
                   CVV = "000",
                   CreatedAt = new DateTime(2024, 1, 15)
               },
               new Card
               {
                   CardId = 2,
                   CustomerId = 2,
                   CardNo = "5500000000000004",   // test kartı (Mastercard)
                   ExpirationDate = "08/27",
                   CVV = "000",
                   CreatedAt = new DateTime(2024, 3, 22)
               },
               new Card
               {
                   CardId = 3,
                   CustomerId = 3,
                   CardNo = "3714496353984312",   // test kartı (Amex)
                   ExpirationDate = "05/26",
                   CVV = "000",
                   CreatedAt = new DateTime(2024, 6, 10)
               }
           );
        }
    }
}
