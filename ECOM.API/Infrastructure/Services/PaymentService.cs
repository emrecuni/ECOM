using System.Globalization;
using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Payment;
using ECOM.Shared.Data.Entities;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request;
using Microsoft.EntityFrameworkCore;
using Status = ECOM.Shared.Data.Enums.Status;

namespace ECOM.API.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;
        private readonly Options _iyzico;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(DataContext context, Options iyzico, ILogger<PaymentService> logger)
        {
            _context = context;
            _iyzico = iyzico;
            _logger = logger;
        }

        public async Task<Response<PaymentResponseDto>> Pay(PaymentRequestDto model)
        {
            Response<PaymentResponseDto> response = new();
            response.Status = Status.Default;

            try
            {
                #region GetCartAndAddress
                var carts = await GetCart(model.CustomerId, isIncludeNavigation: true);

                if (carts is null || carts.Count == 0)
                {
                    response.Status = Status.Error;
                    response.Message = "Sepet boş veya geçersiz.";
                    return response;
                }

                var address = await GetAddress(model);

                if (address is null)
                {
                    response.Status = Status.Error;
                    response.Message = "Adres bulunamadı veya geçersiz.";
                    return response;
                }
                #endregion GetCartAndAddress

                List<BasketItem> basket = basket = carts.Select(cart => new BasketItem
                {
                    Id = cart.ProductId.ToString(),
                    Name = cart.Product.Name,
                    Category1 = cart.Product.SubCategory.Name,
                    Category2 = cart.Product.SupCategory.Name,
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = cart.TotalPrice.ToString("0.00", CultureInfo.InvariantCulture) // iyzico "," ile değil "." ile ondalık ayracı bekliyor
                }).ToList();

                decimal totalPrice = carts.Sum(cart => cart.TotalPrice);

                Address orderAddress = new()
                {
                    City = address?.City.Name,
                    Country = "Türkiye",
                    ContactName = carts[0].Customer.Name + " " + carts[0].Customer.Surname,
                    Description = "test",
                    ZipCode = "34930"
                };

                CreateCheckoutFormInitializeRequest request = new()
                {
                    Locale = Locale.TR.ToString(),
                    ConversationId = Guid.NewGuid().ToString(), //guid oluştur
                    Price = totalPrice.ToString("0.00", CultureInfo.InvariantCulture),
                    PaidPrice = totalPrice.ToString("0.00", CultureInfo.InvariantCulture),
                    Currency = Currency.TRY.ToString(),
                    CallbackUrl = "http://localhost:5195/Payment/Callback",
                    PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                    Buyer = new Buyer
                    {
                        Id = $"BY{model.CustomerId}",
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

                var iyzicoResponse = CheckoutFormInitialize.Create(request, _iyzico);

                response.Status = iyzicoResponse.Status switch
                {
                    TaskStatus.Created => Status.Success,
                    TaskStatus.Faulted => Status.Error,
                    TaskStatus.Canceled => Status.Error,
                    _ => Status.Default
                };
                response.Message = iyzicoResponse.Result.CheckoutFormContent;
            }
            catch (Exception ex)
            {
                _logger.LogError($"PaymentService/Pay ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = $"Ödeme yapılırken bir hata oluştu: {ex.Message}";
            }
            return response;
        }

        private async Task<List<Cart>> GetCart(int customerId, bool isIncludeNavigation)
        {

            return isIncludeNavigation ? await _context.Carts
                .Include(p => p.Product)
                .Include(c => c.Customer)
                .Include(s => s.Seller)
                .Include(p => p.Product.SupCategory)
                .Include(p => p.Product.SubCategory)
                .Where(c => c.CustomerId == customerId && c.Enable)
                .ToListAsync()
                :
                await _context.Carts
                .AsNoTracking()
                .Where(c => c.CustomerId == customerId && c.Enable)
                .Select(c => new Cart {CartId = c.CartId,ProductId = c.ProductId,CustomerId= c.CustomerId, SellerId = c.SellerId, Piece = c.Piece, TotalPrice = c.TotalPrice })
                .ToListAsync();
        }

        private async Task<Addresses?> GetAddress(PaymentRequestDto model)
        {
            return await _context.Addresses
                .Include(c => c.Customer)
                .Include(c => c.City)
                .Include(c => c.District)
                .Include(c => c.Neighbourhood)
                .FirstOrDefaultAsync(a => a.AddressId == model.AddressId && a.CustomerId == model.CustomerId);
        }

        public async Task<Response<CallbackResponseDto>> CallBack(CallbackRequestDto model)
        {
            Response<CallbackResponseDto> response = new();
            response.Status = Status.Default;
            try
            {
                var token = model.Form?["token"];

                if (string.IsNullOrEmpty(token))
                {
                    response.Status = Status.Error;
                    response.Message = "Token bulunamadı veya geçersiz.";
                    return response;
                }

                var request = new RetrieveCheckoutFormRequest
                {
                    Token = token,
                    Locale = Locale.TR.ToString(),
                    ConversationId = Guid.NewGuid().ToString() // sipariş ID vb. kullanılabilir
                };

                var iyzicoResponse = CheckoutForm.Retrieve(request, _iyzico);

                if (iyzicoResponse.Result.Status == "success") // success'i  consttan al
                {
                    using var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        var carts = await GetCart(model.CustomerId, isIncludeNavigation: false);

                        carts.ForEach(async cart =>
                        {
                            cart.Enable = false;
                            _context.Carts.Update(cart);
                        });

                        await _context.SaveChangesAsync();

                        var now = DateTime.Now;

                        var orderList = carts.Select(order => new OrderHistory
                        {
                            ProductId = order.ProductId,
                            CustomerId = order.CustomerId,
                            SellerId = order.SellerId,
                            CartId = order.CartId,
                            Piece = order.Piece,
                            TotalPrice = order.TotalPrice,
                            OrderDate = now
                        });

                        await _context.OrderHistory.AddRangeAsync(orderList);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        response.Status = Status.Success;
                        response.Message = "Ödeme işlemi başarılı ve sipariş oluşturuldu.";
                        response.Result = new CallbackResponseDto
                        {
                            PaymentStatus = iyzicoResponse.Result.Status,
                            PaymentId = iyzicoResponse.Result.PaymentId,
                            Price = decimal.Parse(iyzicoResponse.Result.PaidPrice, CultureInfo.InvariantCulture)
                        };
                        return response;
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        //throw;
                        response.Status = Status.Failed;
                        response.Message = "Ödeme işlemi başarılı ancak db işlemi sırasında hata oluştu.";
                        response.Result = new CallbackResponseDto
                        {
                            PaymentStatus = iyzicoResponse.Result.Status,
                            PaymentId = iyzicoResponse.Result.PaymentId,
                            Price = decimal.Parse(iyzicoResponse.Result.PaidPrice, CultureInfo.InvariantCulture)
                        };
                        return response;
                    }                    
                }
                else
                {
                    response.Status = Status.Error;
                    response.Message = "Ödeme işlemi başarısız.";
                    response.Result = new CallbackResponseDto
                    {
                        ResultMessage = iyzicoResponse.Result.ErrorMessage,
                    };
                }
            }
            catch (Exception ex)
            {
                response.Status = Status.Error;
                response.Message = $"Ödeme callback işlemi sırasında bir hata oluştu: {ex.Message}";                
            }
            return response;
        }
    }
}
