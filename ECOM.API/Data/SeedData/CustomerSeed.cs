using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class CustomerSeed : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasData(
                new Customers
                {
                    CustomerId = 1,
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    Email = "ahmet.yilmaz@gmail.com",
                    Phone = "05321234567",
                    Password = "gDdBkms2Z3g8T43jHKcphA==$lBOYfNxnf13JEUqZLLvgQ7ytu3NoYySvUOcQGSOd1PI=$3.32768.2",  // production'da hash'li olmalı
                    Gender = true,
                    IsCustomer = true,
                    BirthDate = new DateTime(1990, 5, 15),
                    CreatedAt = new DateTime(2024, 1, 10),
                    UpdatedAt = new DateTime(2024, 1, 10)
                },
                new Customers
                {
                    CustomerId = 2,
                    Name = "Ayşe",
                    Surname = "Kaya",
                    Email = "ayse.kaya@gmail.com",
                    Phone = "05339876543",
                    Password = "HlfQh6k799FJUKAnqBVKgA==$jb8mRVf3nPXxaJbKua8tTNncbhmK1WsnOLIjsGc/Rww=$3.32768.2",
                    Gender = false,
                    IsCustomer = true,
                    BirthDate = new DateTime(1995, 8, 22),
                    CreatedAt = new DateTime(2024, 2, 18),
                    UpdatedAt = new DateTime(2024, 3, 5)
                },
                new Customers
                {
                    CustomerId = 3,
                    Name = "Mehmet",
                    Surname = "Demir",
                    Email = "mehmet.demir@hotmail.com",
                    Phone = "05453456789",
                    Password = "8ljtPIZfCw9rZDKIHLlSQA==$1vK4aLmq9qDA4o/am0VuGPUZNz6lnnRQGtj+0wYMWhY=$3.32768.2",
                    Gender = true,
                    IsCustomer = true,
                    BirthDate = new DateTime(1988, 11, 3),
                    CreatedAt = new DateTime(2024, 4, 25),
                    UpdatedAt = new DateTime(2024, 4, 25)
                }
            );
        }
    }
}
