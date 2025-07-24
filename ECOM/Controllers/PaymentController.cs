using Azure;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Options _iyzico;

        public PaymentController(IConfiguration config)
        {
            _iyzico = new Options
            {
                ApiKey = config["IyzicoOptions:ApiKey"],
                SecretKey = config["IyzicoOptions:SecretKey"],
                BaseUrl = config["IyzicoOptions:BaseUrl"]
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pay()
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
                    City= "İstanbul",
                    Country = "Türkiye",
                    Description = "Test test test",
                    ZipCode= "34930"
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

            if(response.Result.Status == "success")
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
