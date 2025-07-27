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
        public IActionResult Pay(AddressViewModel model)
        {
            var request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "100",
                PaidPrice = "100",
                Currency = Currency.TRY.ToString(),
                CallbackUrl = "https://localhost:7064/Payment/Callback",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                Buyer = new Buyer
                {
                    Id = "BY789",
                    Name = "Emre",
                    Surname = "Cüni",
                    Email = "cuniiemre@gmail.com",
                    GsmNumber = "+905459690208",
                    IdentityNumber = "12345678901",
                    RegistrationAddress = "İstanbul, Türkiye",
                    Ip = "85.34.78.112",
                    City = "İstanbul",
                    Country = "Turkey",
                },
                BasketItems = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Id = "BI101",
                        Name = "Product 1",
                        Category1 = "Category 1",
                        ItemType = BasketItemType.PHYSICAL.ToString(),
                        Price = "100"
                    }
                },
                ShippingAddress = new Address
                {
                    ContactName = "Emre Cüni",
                    City = "İstanbul",
                    Country = "Türkiye",
                    Description = "Test test test",
                    ZipCode = "34930"
                },
                BillingAddress = new Address
                {
                    ContactName = "Emre Cüni",
                    City = "İstanbul",
                    Country = "Türkiye",
                    Description = "Test fatura adresi",
                    ZipCode = "34000"
                }
            };

            var response = CheckoutFormInitialize.Create(request, _iyzico);

            ViewBag.CheckoutFormContent = response.Result.CheckoutFormContent; // Iyzico'dan gelen ödeme formu içeriği

            return View();
        }

        [HttpPost]
        public IActionResult Callback(IFormCollection form)
        {
            var token = form["token"];

            if (string.IsNullOrEmpty(token))
                return View("Error");

            var request = new RetrieveCheckoutFormRequest
            {
                Token = token,
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789" // sipariş ID vb. kullanılabilir
            };


            var response = CheckoutForm.Retrieve(request, _iyzico);

            if (response.Result.Status == "success")
            {
                ViewBag.PaymentStatus = "Ödeme Başarılı";
                ViewBag.PaymentId = response.Result.PaymentId;
                ViewBag.Price = response.Result.Price;

                return View("Success");
            }
            else
            {
                ViewBag.ErrorMessage = response.Result.ErrorMessage;
                return View("Error");
            }
        }
    }
}
