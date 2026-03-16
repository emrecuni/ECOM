using ECOM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOM.API.Data.SeedData
{
    public class AddressSeed : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {
            builder.HasData(
                new Addresses
                {
                    AddressId = 1,
                    CustomerId = 1,
                    AddressName = "Ev",
                    Address = "Moda Cad. No:12 D:3",
                    CityId = 1,
                    DistrictId = 1,
                    NeighbourhoodId = 1,
                    ReceiverId = 1,         // müşteri kendisi teslim alıyor
                    AdditionTime = new DateTime(2024, 1, 10)
                },
                new Addresses
                {
                    AddressId = 2,
                    CustomerId = 1,
                    AddressName = "İş yeri",
                    Address = "Levent Mah. Büyükdere Cad. No:45 Kat:7",
                    CityId = 1,
                    DistrictId = 2,
                    NeighbourhoodId = 3,
                    ReceiverId = 1,
                    AdditionTime = new DateTime(2024, 2, 5)
                },
                new Addresses
                {
                    AddressId = 3,
                    CustomerId = 2,
                    AddressName = "Ev",
                    Address = "Fenerbahçe Mah. Bağdat Cad. No:78",
                    CityId = 1,
                    DistrictId = 1,
                    NeighbourhoodId = 2,
                    ReceiverId = 2,
                    AdditionTime = new DateTime(2024, 3, 18)
                },
                new Addresses
                {
                    AddressId = 4,
                    CustomerId = 2,
                    AddressName = "Annem",           // farklı alıcı
                    Address = "Etiler Mah. Nisbetiye Cad. No:5 D:8",
                    CityId = 1,
                    DistrictId = 2,
                    NeighbourhoodId = 4,
                    ReceiverId = 3,         // CustomerId=3 olan kişi teslim alacak
                    AdditionTime = new DateTime(2024, 4, 22)
                },
                new Addresses
                {
                    AddressId = 5,
                    CustomerId = 3,
                    AddressName = "Ev",
                    Address = "Kızılay Mah. Atatürk Bulvarı No:101 D:2",
                    CityId = 2,
                    DistrictId = 4,
                    NeighbourhoodId = 5,
                    ReceiverId = 3,
                    AdditionTime = new DateTime(2024, 5, 30)
                }
            );
        }
    }
}
