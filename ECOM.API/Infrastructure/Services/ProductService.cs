using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(DataContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Response<string>> AddCart(AddCartRequestDto model)
        {
            Response<string> response = new();
            try
            {
                Console.WriteLine("ProductService/AddCart ==> Metodu çalışmaya başladı");
                #region Gönderilen fiyat ile db'deki fiyatı karşılaştırma
                CheckPriceDiffDto priceDiffModel = new()
                {
                    ProductId = model.ProductId,
                    Price = model.Price
                };


                response = await CheckPriceDiff(priceDiffModel);
                if (response.Status != Status.Success)
                    return response; // fiyat farkı büyükse işlemi durdur

                #endregion

                var cartItem = new Cart
                {
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId,
                    SellerId = model.SellerId,
                    Piece = model.Piece,
                    TotalPrice = model.Price * model.Piece,
                    Enable = model.Enable,
                    AdditionTime = DateTime.Now
                };

                await _context.Carts.AddAsync(cartItem); // ürün sepete eklenir
                await _context.SaveChangesAsync(); // değişiklikler kaydedilir

                response.Status = Status.Success;
                response.Message = "Ürün sepete başarıyla eklendi.";
                response.Result = $"ProductId: {model.ProductId}"; // eklenen ürünün id'si döndürülür
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/AddCart ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<string>> EditCart(EditCartRequestDto model)
        {
            Response<string> response = new();
            try
            {
                // burada direkt cart id'sini gönderebilirsen onun üzerinden al
                var cartItem = await _context.Carts.FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId &&
                    c.ProductId == model.ProductId &&
                    c.SellerId == model.SellerId);

                if (cartItem is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Sepet ürünü bulunamadı.";
                    return response;
                }

                // fiyat karşılaştırma yapmak gerekirse request'e price değerini ekle
                //#region Gönderilen fiyat ile db'deki fiyatı karşılaştırma
                //CheckPriceDiffDto priceDiffModel = new()
                //{
                //    ProductId = model.ProductId,
                //    Price = model.Price
                //};

                //response = await CheckPriceDiff(priceDiffModel);
                //if (response.Status != Status.Success)
                //    return response; // fiyat farkı büyükse işlemi durdur

                //#endregion


                /*
                 * fiyat karşılaştırma yap ve fiyatı ona göre güncelle
                 */

                var price = await _context.Products
                    .AsNoTracking()
                    .Where(p => p.ProductId == model.ProductId)
                    .Select(p => p.Price)
                    .FirstOrDefaultAsync();

                cartItem.Piece = model.Piece;
                cartItem.Enable = model.Enable;
                cartItem.TotalPrice = price * model.Piece;

                await _context.SaveChangesAsync(); // değişiklikler kaydedilir

                Console.WriteLine("ProductService/EditCart ==> Sepet güncellendi db'ye yazıldı");
                response.Status = Status.Success;
                response.Message = "Sepet Başarıyla Güncellendi.";
                response.Result = $"CartId: {cartItem.CartId}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/RemoveCart ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CartResponseDto>> GetCart(int customerId)
        {
            Response<CartResponseDto> response = new();
            try
            {
                // kullanıcın sepetteki bütün ürünleri çekilir
                var cartItems = await _context.Carts
                    .Where(c => c.CustomerId == customerId)
                    .Select(c => new ProductOfCartDto
                    {
                        Id = c.ProductId,
                        Name = c.Product.Name,
                        Price = c.TotalPrice,
                        Piece = c.Piece,
                        ImagePath = c.Product.ImagePath,
                        Enable = c.Enable,
                        SellerId = c.SellerId,
                        SellerName = c.Seller.Name
                    })
                    .ToListAsync();

                if (cartItems is null || cartItems.Count == 0) // sepet boşsa
                {
                    response.Status = Status.Failed;
                    response.Message = "Sepette ürün bulunamadı.";
                    return response;
                }

                response.Result = new CartResponseDto
                {
                    Products = cartItems,
                    TotalPiece = cartItems.Where(c => c.Enable).Sum(c => c.Piece), // sadece aktif olan ürünlerin adedi alınır
                    TotalPrice = cartItems.Where(c => c.Enable).Sum(c => c.Price) // sadece aktif olan ürünlerin fiyatları alınır
                };

                response.Status = Status.Success;
                response.Message = "Sepetteki ürünler başarıyla getirildi.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetCart ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<Response<int>> AddFavorite()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<BasicProductResponseDto>>> GetFavoriteProducts(int customerId)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                var favoriteProducts = await _context.Favorites
                    .Where(f => f.CustomerId == customerId)
                    .Select(f => new BasicProductResponseDto
                    {
                        ProductId = f.Product.ProductId,
                        Name = f.Product.Name,
                        Price = f.Product.Price,
                        Score = f.Product.Score,
                        ImagePath = f.Product.ImagePath,
                        IsFavorite = true
                    })
                    .ToListAsync();

                response.Result = favoriteProducts;
                response.Status = favoriteProducts.Count > 0 ? Status.Success : Status.Failed;
                response.Message = favoriteProducts.Count > 0 ? "Favori ürünler başarıyla getirildi." : "Favori ürün bulunamadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetFavoriteProducts ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DetailProductResponseDto>> GetProductDetails(DetailProductRequestDto model)
        {
            Response<DetailProductResponseDto> response = new();
            try
            {
                var product = await _context.Products
                    .Where(p => p.ProductId == model.ProductId)
                    .Select(p => new DetailProductResponseDto
                    {
                        ProductId = p.ProductId,
                        BrandId = p.BrandId,
                        BrandName = p.Brand.Name,
                        SupCategoryId = p.SupCategoryId,
                        SupCategory = p.SupCategory.Name,
                        SubCategoryId = p.SubCategoryId,
                        SubCategory = p.SubCategory.Name,
                        SellerId = p.SellerId,
                        SellerName = p.Seller.Name,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Score = p.Score,
                        ImagePath = p.ImagePath,
                        Comments = p.Comments.Select(c => new CommentsDto
                        {
                            CommentId = c.CommentId,
                            CustomerName = c.Customer.Name,
                            CustomerSurname = c.Customer.Surname,
                            Score = c.Score,
                            ImagePath = c.ImagePath,
                            Comment = c.Comment
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (product is not null && model.CustomerId.HasValue)
                    product.IsFavorite = await _context.Favorites.AnyAsync(f => f.CustomerId == model.CustomerId && f.ProductId == model.ProductId); // favori kontrolü

                response.Status = product is not null ? Status.Success : Status.Failed;
                response.Message = product is not null ? "Ürün başarıyla getirildi." : "Ürün bulunamadı.";
                response.Result = product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetProductDetails ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<BasicProductResponseDto>>> GetProducts(int? customerId)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                // db'den 20 ürün çeker
                var products = await _context.Products
                    .Take(20)
                    .Select(p => new { p.ProductId, p.Name, p.Price, p.Score, p.ImagePath })
                    .ToListAsync();

                // db'den kullanıcın favorilere attığı ürünlerin id'lerini çeker
                var favorites = await _context.Favorites
                    .Where(f => f.CustomerId == customerId)
                    .Select(f => f.ProductId)
                    .ToListAsync();

                response.Result = [.. products.Select(p => new BasicProductResponseDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Score = p.Score,
                    ImagePath = p.ImagePath,
                    IsFavorite = favorites.Contains(p.ProductId) // ürün favoriler arasında mı kontrolü
                })];

                response.Status = response.Result.Count > 0 ? Status.Success : Status.Failed;
                response.Message = response.Result.Count > 0 ? "Ürünler başarıyla getirildi." : "Ürün bulunmadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetProducts ==> Error: {ex} ");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        private async Task<Response<string>> CheckPriceDiff(CheckPriceDiffDto model)
        {
            Response<string> response = new();
            try
            {
                Console.WriteLine("ProductService/CheckPriceDiff ==> Metodu çalışmaya başladı");
                // ürünün db'deki fiyatını alır,
                var product = await _context.Products
                    .Select(p => new { p.ProductId, p.Price })
                    .FirstOrDefaultAsync(p => p.ProductId == model.ProductId);

                if (product is null)
                {
                    Console.WriteLine($"ProductService/CheckPriceDiff ==> product is null {model.ProductId}");
                    response.Status = Status.Failed;
                    response.Message = "Ürün bulunamadı.";
                    return response;
                }

                if (model.Price != product.Price)
                {
                    Console.WriteLine($"ProductService/CheckPriceDiff ==> Fiyat uyuşmazlığı: model.Price:{model.Price} - product.Price:{product.Price}");
                    _logger.LogWarning($"ProductService/CheckPriceDiff ==> Fiyat uyuşmazlığı: Gönderilen fiyat: {model.Price}, DB fiyatı: {product.Price}");

                    // fiyat farkı yüzde 10'den fazla ise kullanıcıyı uyar, değilse db'deki fiyatı kullan
                    var priceDiff = Math.Abs(product.Price - model.Price) / product.Price * 100;
                    if (priceDiff > 10)
                    {
                        response.Status = Status.Failed;
                        response.Message = $"Fiyat uyuşmazlığı tespit edildi. Gönderilen fiyat: {model.Price}, DB fiyatı: {product.Price}. Lütfen fiyatı kontrol edin.";
                        response.Result = $"ProductId: {model.ProductId}"; // ürün id'si döndürülür, böylece kullanıcı hangi ürünün fiyatında sorun olduğunu görebilir

                        return response;
                    }
                }
                response.Result = $"ProductId: {model.ProductId}"; // fiyat farkı yüzde 10'dan az ise gönderilen fiyatı kullan
                response.Status = Status.Success;
                response.Message = "Fiyat uyuşmazlığı tespit edildi ancak fark yüzde 10'dan az olduğu için gönderilen fiyat kullanıldı.";
                Console.WriteLine($"ProductService/CheckPriceDiff ==> Fiyat uyuşmazlığı tespit edildi ancak fark yüzde 10'dan az model.Price:{model.Price} - product.Price:{product.Price}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ProductService/CheckPriceDiff ==> Error: {ex}");
                _logger.LogError($"ProductService/CheckPriceDiff ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
