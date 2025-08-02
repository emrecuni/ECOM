using Azure;
using ECOM.Data;
using ECOM.Models;
using ECOM.Services;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Options _iyzico;
        private readonly DataContext _context;

        public PaymentController(IConfiguration config, DataContext context)
        {
            _iyzico = new Options
            {
                ApiKey = config["IyzicoOptions:ApiKey"],
                SecretKey = config["IyzicoOptions:SecretKey"],
                BaseUrl = config["IyzicoOptions:BaseUrl"]
            };
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır
                var addresses = await _context.Addresses
                    .Include(a => a.City)
                    .Include(a => a.District)
                    .Include(a => a.Neighbourhood)
                    .ToListAsync();

                var cart = await _context.Carts
                    .Include(c => c.Customer)
                    .Include(c => c.Product)
                    .Include(c => c.Seller)
                    .Include(c => c.Coupon)
                    .Where(c => c.CustomerId == customerId && c.Enable == true)
                    .ToListAsync();

                var cities = await _context.Cities.ToListAsync();

                //var disricts = await _context.Districts
                //    .Include(d => d.City)
                //    .ToListAsync();

                //var neighbourhoods = await _context.Neighbourhoods
                //    .Include(n => n.City)
                //    .Include(n => n.District)
                //    .ToListAsync();                    

                AddressViewModel model = new AddressViewModel
                {
                    Addresses = addresses,
                    Cart = cart,
                    Cities = cities
                    //Districts = disricts,
                    //Neighbourhoods = neighbourhoods
                };

                return View(model);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Payment/Index Error => {ex}");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDistrictsAsync(int cityId)
        {
            try
            {
                var disricts = await _context.Districts
                    .Where(d => d.CityId == cityId)
                    .Select(d => new { d.DistrictId, d.Name })
                    .OrderBy(d => d.Name)
                    .ToListAsync();

                return Json(disricts);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"GetDistricts Error => {ex}");
                return Json(null);

            }
        }

        [HttpGet]
        public async Task<JsonResult> GetNeighbourhoodsAsync(int districtId)
        {
            try
            {
                var neighbourhoods = await _context.Neighbourhoods
                    .Where(n => n.DistrictId == districtId)
                    .Select(n => new { n.NeighbourhoodId, n.Name })
                    .OrderBy(n => n.Name)
                    .ToListAsync();

                return Json(neighbourhoods);
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"GetDistricts Error => {ex}");
                return Json(null);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Pay(string addressId)
        {
            try
            {
                //view'dan gönderilen json'lar deserialize edilir
                //var address = JsonConvert.DeserializeObject<Addresses>(jsonAddress);
                if (addressId is null)
                    return View("Error", new { message = "Adres seçimi yapınız." });


                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır

                //var cartIds = cartList.Select(c => c.CartId).ToList();
                // sepetteki ürünler db'den çekilir
                var carts = await _context.Carts
                    .Include(p => p.Product)
                    .Include(p => p.Customer)
                    .Include(p => p.Seller)
                    .Include(p => p.Product.SupCategory)
                    .Include(p => p.Product.SubCategory)
                    .Where(c => c.CustomerId == customerId && c.Enable == true)
                    .ToListAsync();
                if (carts is null || carts.Count == 0)
                    return View("Error", new { message = "Sepet boş veya geçersiz." });

                // seçilen adres db'den çekilir
                var validAddress = await _context.Addresses
                    .Include(a => a.City)
                    .Include(a => a.District)
                    .Include(a => a.Neighbourhood)
                    .FirstOrDefaultAsync(a => a.AddressId == int.Parse(addressId));

                List<BasketItem> basket = new();
                float totalPrice = 0;

                
                // ödeme request'i için sepetteki ürünler basketitem list'e eklenir
                foreach (var basketItem in carts)
                {
                    basket.Add(new BasketItem
                    {
                        Id = $"BI{basketItem.CartId}",
                        Name = basketItem.Product.Name,
                        Category1 = basketItem.Product.SupCategory.Name,
                        Category2 = basketItem.Product.SubCategory.Name,
                        ItemType = BasketItemType.PHYSICAL.ToString(),
                        Price = basketItem.TotalPrice.ToString("0.00", CultureInfo.InvariantCulture) // iyzico "," ile değil "." ile ondalık ayracı bekliyor
                    });
                    totalPrice += (float)basketItem.TotalPrice; // toplam fiyat hesaplanır
                }

                // ödeme için adres bilgileri hazırlanır
                Address orderAddress = new()
                {
                    City = validAddress?.City.Name,
                    Country = "Türkiye",
                    ContactName = carts[0].Customer.Name + " " + carts[0].Customer.Surname,
                    Description = "test",
                    ZipCode = "34930"
                };

                // istek hazırlanır
                var request = new CreateCheckoutFormInitializeRequest
                {
                    Locale = Locale.TR.ToString(),
                    ConversationId = Guid.NewGuid().ToString(), //guid oluştur
                    Price = totalPrice.ToString("0.00", CultureInfo.InvariantCulture),
                    PaidPrice = totalPrice.ToString("0.00", CultureInfo.InvariantCulture),
                    Currency = Currency.TRY.ToString(),
                    CallbackUrl = "https://localhost:7064/Payment/Callback",
                    PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                    Buyer = new Buyer
                    {
                        Id = $"BY{customerId}",
                        Name = carts[0].Customer.Name,
                        Surname = carts[0].Customer.Surname,
                        Email = carts[0].Customer.Email,
                        GsmNumber = $"+90{carts[0].Customer.Phone}",
                        IdentityNumber = "12345678901",
                        RegistrationAddress = "İstanbul, Türkiye",
                        Ip = "85.34.78.112",
                        City = "İstanbul",
                        Country = "Turkey",
                    },
                    BasketItems = basket,
                    ShippingAddress = orderAddress,
                    BillingAddress = orderAddress
                };

                var response = CheckoutFormInitialize.Create(request, _iyzico);

                ViewBag.CheckoutFormContent = response.Result.CheckoutFormContent; // Iyzico'dan gelen ödeme formu içeriği

                return View();
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Payment/Pay Error => {ex}");
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Callback(IFormCollection form)
        {
            try
            {
                var token = form["token"];

                if (string.IsNullOrEmpty(token))
                    return View("Error");

                var request = new RetrieveCheckoutFormRequest
                {
                    Token = token,
                    Locale = Locale.TR.ToString(),
                    ConversationId = Guid.NewGuid().ToString() // sipariş ID vb. kullanılabilir
                };


                var response = CheckoutForm.Retrieve(request, _iyzico);

                if (response.Result.Status == "success")
                {
                    try
                    {
                        int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır
                        var carts = await _context.Carts
                            .Where(c => c.CustomerId == customerId && c.Enable == true)
                            .ToListAsync();

                        for (int i = 0; i < carts.Count; i++)
                            carts[i].Enable = false; // sepet ürünleri ödeme sonrası devre dışı bırakılır

                        _context.Carts.UpdateRange(carts); // sepet güncellenir
                        await _context.SaveChangesAsync(); // veri tabanına kaydedilir
                    }
                    catch (Exception ex)
                    {
                        NLogger.logger.Error($"Payment/Callback Success Error => {ex}");
                    }
                    ViewBag.PaymentStatus = "Ödeme Başarılı";
                    ViewBag.PaymentId = response.Result.PaymentId;
                    ViewBag.Price = float.Parse(response.Result.Price.Replace(".", ","));

                    return View("Success");
                }
                else
                {
                    ViewBag.ErrorMessage = response.Result.ErrorMessage;
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"Payment/Callback Error => {ex}");
                return View("Error");
            }
        }
    }
}
