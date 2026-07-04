using System.Globalization;
using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.Constants;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Payment;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
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
        private readonly IConfiguration _config;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(DataContext context, Options iyzico, IConfiguration config, ILogger<PaymentService> logger)
        {
            _context = context;
            _iyzico = iyzico;
            _config = config;
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
                    CallbackUrl = _config["Iyzico:CallbackUrl"],
                    PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                    Buyer = new Buyer
                    {
                        Id = $"BY{model.CustomerId}",
                        Name = carts[0].Customer.Name,
                        Surname = carts[0].Customer.Surname,
                        Email = carts[0].Customer.Email,
                        GsmNumber = $"+90{carts[0].Customer.Phone}",
                        IdentityNumber = "12345678901",
                        RegistrationAddress = $"{orderAddress.City}, Türkiye",
                        Ip = "85.34.78.112",
                        City = orderAddress.City,
                        Country = "Turkey",
                    },
                    BasketItems = basket,
                    ShippingAddress = orderAddress,
                    BillingAddress = orderAddress
                };

                var iyzicoResponse = await CheckoutFormInitialize.Create(request, _iyzico);

                switch (iyzicoResponse.Status)
                {
                    case PaymentConstants.IyzicoResponseSuccessStatus:
                        response.Status = Status.Success;
                        response.Message = "İşlem başarılı.";
                        _logger.LogInformation($"PaymentService/Pay ==> İyzico ödeme formu oluşturuldu. Token: {iyzicoResponse.Token}");
                        break;
                    case PaymentConstants.IyzicoResponseFailureStatus:
                        response.Status = Status.Failed;
                        response.Message = "İşlem başarısız.";
                        _logger.LogWarning($"PaymentService/Pay ==> İyzico ödeme formu oluşturulamadı. ErrorCode: {iyzicoResponse.ErrorCode}, ErrorMessage: {iyzicoResponse.ErrorMessage}");
                        break;
                    default:
                        response.Status = Status.Error;
                        response.Message= "Bir hata oluştu.";   
                        _logger.LogError($"PaymentService/Pay ==> İyzico ödeme formu oluşturulamadı. Status: {iyzicoResponse.Status}, ErrorCode: {iyzicoResponse.ErrorCode}, ErrorMessage: {iyzicoResponse.ErrorMessage}");
                        break;
                }
                response.Result = new PaymentResponseDto()
                {
                    Content = iyzicoResponse.CheckoutFormContent,
                    ErrorCode = iyzicoResponse.ErrorCode,
                    ErrorGroup = iyzicoResponse.ErrorGroup,
                    ErrorMessage = iyzicoResponse.ErrorMessage
                };

                if (response.Status == Status.Success)
                {
                    using var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        PaymentSession paymentSession = new()
                        {
                            ConversationId = request.ConversationId,
                            Token = iyzicoResponse.Token,
                            CustomerId = model.CustomerId,
                            ExpectedAmount = totalPrice,
                            Status = PaymentSessionStatus.Pending,
                            CreatedAt = DateTime.Now
                        };

                        await _context.PaymentSessions.AddAsync(paymentSession);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        response.Status = Status.Failed;
                        response.Message = "İşlemi başarılı ancak db işlemi sırasında hata oluştu.";
                        return response;
                    }
                }
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
                .Select(c => new Cart { CartId = c.CartId, ProductId = c.ProductId, CustomerId = c.CustomerId, SellerId = c.SellerId, Piece = c.Piece, TotalPrice = c.TotalPrice })
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

        public async Task<Response<CallbackResponseDto>> CallBack(string token)
        {
            Response<CallbackResponseDto> response = new();
            response.Status = Status.Default;
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    response.Status = Status.Error;
                    response.Message = "Token bulunamadı veya geçersiz.";
                    return response;
                }

                var session = await _context.PaymentSessions.FirstOrDefaultAsync(s => s.Token == token);

                if (session is null)
                {
                    response.Status = Status.Error;
                    response.Message = "Ödeme oturumu bulunamadı.";
                    return response;
                }
                else if (session.Status == PaymentSessionStatus.Completed)
                {
                    response.Status = Status.Error;
                    response.Message = "Ödeme oturumu zaten tamamlanmış.";
                    return response;
                }

                var now = DateTime.UtcNow;

                var claimed = await _context.PaymentSessions
                .Where(s => s.Token == token &&
                (s.Status == PaymentSessionStatus.Pending ||
                 (s.Status == PaymentSessionStatus.Processing &&
                  s.ProcessingStartedAt < now.AddMinutes(-2))))
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.Status, PaymentSessionStatus.Processing)
                    .SetProperty(x => x.ProcessingStartedAt, now));

                if (claimed == 0)
                {
                    response.Status = Status.Failed;
                    response.Message = "Ödeme zaten işleniyor/işlenmiş.";
                }

                var request = new RetrieveCheckoutFormRequest
                {
                    Token = token,
                    Locale = Locale.TR.ToString(),
                    ConversationId = Guid.NewGuid().ToString() // sipariş ID vb. kullanılabilir
                };

                var iyzicoResponse = await CheckoutForm.Retrieve(request, _iyzico);

                if (iyzicoResponse.Status == PaymentConstants.IyzicoResponseSuccessStatus) 
                {
                    // gönderilen tutar ile beklenen tutarı karşılaştır
                    if (!decimal.TryParse(iyzicoResponse.PaidPrice, NumberStyles.Number, CultureInfo.InvariantCulture, out var paidPrice))
                    {
                        response.Status = Status.Error;
                        response.Message = "Ödeme tutarı okunamadı.";
                        return response;
                    }

                    if (paidPrice != session.ExpectedAmount)
                    {
                        response.Status = Status.Error;
                        response.Message = "Ödeme tutarı beklenen tutarla eşleşmiyor.";
                        return response;
                    }

                    using var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        var carts = await GetCart(session.CustomerId, isIncludeNavigation: false); // customerId'yi iyzicoResponse'dan alabiliriz, şimdilik 1 olarak sabitledim

                        carts.ForEach(async cart =>
                        {
                            cart.Enable = false;
                            _context.Carts.Update(cart);
                        });

                        now = DateTime.Now;

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

                        session.Status = PaymentSessionStatus.Completed;
                        session.ProcessedAt = now;
                        session.PaymentId = iyzicoResponse.PaymentId;

                        await _context.OrderHistory.AddRangeAsync(orderList);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        response.Status = Status.Success;
                        response.Message = "Ödeme işlemi başarılı ve sipariş oluşturuldu.";
                        response.Result = new CallbackResponseDto
                        {
                            PaymentStatus = iyzicoResponse.Status,
                            PaymentId = iyzicoResponse.PaymentId,
                            Price = decimal.Parse(iyzicoResponse.PaidPrice, CultureInfo.InvariantCulture),
                            ErrorCode = iyzicoResponse.ErrorCode,
                            ErrorGroup = iyzicoResponse.ErrorGroup,
                            ErrorMessage = iyzicoResponse.ErrorMessage
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
                            PaymentStatus = iyzicoResponse.Status,
                            PaymentId = iyzicoResponse.PaymentId,
                            Price = decimal.Parse(iyzicoResponse.PaidPrice, CultureInfo.InvariantCulture),
                            ErrorCode = iyzicoResponse.ErrorCode,
                            ErrorGroup = iyzicoResponse.ErrorGroup,
                            ErrorMessage = iyzicoResponse.ErrorMessage
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
                        ErrorCode = iyzicoResponse.ErrorCode,
                        ErrorGroup = iyzicoResponse.ErrorGroup,
                        ErrorMessage = iyzicoResponse.ErrorMessage
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
