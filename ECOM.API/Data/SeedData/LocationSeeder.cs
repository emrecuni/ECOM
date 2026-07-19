using System.Text.Json;
using ECOM.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECOM.API.Data.SeedData
{
    public class LocationSeeder
    {
        public static async Task SeedAsync(DataContext context)
        {

            /*******************************************************************
             * Her çalıştırmada tetiklenmemesi için yorum satırı haline getirildi.
             * 
             */

            //if (!context.Cities.Any()) return;

            //var json = await File.ReadAllTextAsync("Data/il_ilce_mahalle.json");
            //var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(json);

            //if (data == null) return;

            //// CityId 1-81 arası zaten CitySeedData ile oluşturuldu
            //// İl adına göre CityId eşleştirmesi
            //var cities = await context.Cities.ToListAsync();
            //var cityLookup = cities.ToDictionary(c => c.Name!.ToUpper(), c => c.CityId);

            //int districtId = 1;

            //var districts = new List<District>();
            //var neighbourhoods = new List<Neighbourhood>();

            //foreach (var (cityName, ilceler) in data)
            //{
            //    if (!cityLookup.TryGetValue(cityName.ToUpper(), out int cityId))
            //        continue;

            //    foreach (var (districtName, mahalleler) in ilceler)
            //    {
            //        var district = new District
            //        {
            //            CityId = cityId,
            //            Name = districtName
            //        };
            //        districts.Add(district);

            //        foreach (var mahalleName in mahalleler)
            //        {
            //            neighbourhoods.Add(new Neighbourhood
            //            {
            //                DistrictId = districtId,
            //                Name = mahalleName,
            //                ZipCode = null   // bu JSON'da zipcode yok
            //            });
            //        }

            //        districtId++;
            //    }
            //}

            //await context.Districts.AddRangeAsync(districts);
            //await context.SaveChangesAsync();

            //await context.Neighbourhoods.AddRangeAsync(neighbourhoods);
            //await context.SaveChangesAsync();
        }
    }
}
