using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECOM.API.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductService> _logger;

        // sepet ile db fiyatı arasında kabul edilen en yüksek fark (yüzde)
        private const decimal PriceTolerancePercent = 10;

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

                response = await CheckPriceDiff(new CheckPriceDiffDto
                {
                    ProductId = model.ProductId,
                    Price = model.Price
                });

                if (response.Status != Status.Success)
                    return response; // fiyat farkı büyükse işlemi durdur

                #endregion

                #region Sepete eklenecek ürün satıcıda mevcut mu

                if (!await _context.Products
                    .AnyAsync(p => p.ProductId == model.ProductId && p.SellerId == model.SellerId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Sepete eklenmek ürün satıcıda mevcut değil.";
                    response.Result = $"ProductId: {model.ProductId}";
                    return response;
                }

                #endregion Sepete eklenecek ürün satıcıda mevcut mu

                var cartItem = await _context.Carts
                    .FirstOrDefaultAsync(c => c.CustomerId == model.CustomerId &&
                                              c.ProductId == model.ProductId &&
                                              c.SellerId == model.SellerId);

                if (cartItem is not null)
                {
                    cartItem.Piece += model.Piece; // mevcut ürünün adedini güncelle
                    cartItem.TotalPrice += model.Price * model.Piece; // toplam fiyatı güncelle

                    _context.Carts.Update(cartItem); // ürün sepette güncellenir

                    response.Status = Status.Success;
                    response.Message = "Sepetteki ürün adedi güncellendi.";
                    response.Result = $"ProductId: {model.ProductId}";
                    return response;
                }
                else
                {
                    await _context.Carts.AddAsync(new Cart
                    {
                        CustomerId = model.CustomerId,
                        ProductId = model.ProductId,
                        SellerId = model.SellerId,
                        Piece = model.Piece,
                        TotalPrice = model.Price * model.Piece,
                        Enable = model.Enable,
                        CreatedAt = DateTime.Now
                    }); // ürün sepete eklenir

                    response.Status = Status.Success;
                    response.Message = "Ürün sepete başarıyla eklendi.";
                    response.Result = $"ProductId: {model.ProductId}"; // eklenen ürünün id'si döndürülür
                }

                await _context.SaveChangesAsync(); // değişiklikler kaydedilir
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

                #region Sepetteki birim fiyat ile db'deki fiyatı karşılaştırma

                // fiyat istemciden alınmaz; sepete eklendiği andaki birim fiyat db'deki güncel fiyatla karşılaştırılır
                var dbPrice = await _context.Products
                    .AsNoTracking()
                    .Where(p => p.ProductId == model.ProductId)
                    .Select(p => (decimal?)p.Price)
                    .FirstOrDefaultAsync();

                if (dbPrice is null)
                {
                    response.Status = Status.Failed;
                    response.Message = "Ürün bulunamadı.";
                    return response;
                }

                var cartUnitPrice = cartItem.Piece > 0 ? cartItem.TotalPrice / cartItem.Piece : dbPrice.Value;
                var unitPrice = cartUnitPrice;
                bool priceUpdated = false;

                // fark tolerans değerinin üzerindeyse sepetteki fiyat db'deki güncel fiyatla değiştirilir
                if (dbPrice.Value > 0 && Math.Abs(dbPrice.Value - cartUnitPrice) / dbPrice.Value * 100 > PriceTolerancePercent)
                {
                    _logger.LogWarning($"ProductService/EditCart ==> Fiyat güncellendi: CartId: {cartItem.CartId}, sepet fiyatı: {cartUnitPrice}, DB fiyatı: {dbPrice.Value}");
                    unitPrice = dbPrice.Value;
                    priceUpdated = true;
                }

                #endregion Sepetteki birim fiyat ile db'deki fiyatı karşılaştırma

                cartItem.Piece = model.Piece;
                cartItem.Enable = model.Enable;
                cartItem.TotalPrice = unitPrice * model.Piece;
                cartItem.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync(); // değişiklikler kaydedilir

                Console.WriteLine("ProductService/EditCart ==> Sepet güncellendi db'ye yazıldı");
                response.Status = Status.Success;
                response.Message = priceUpdated ? "Ürünün fiyatı değiştiği için sepetteki fiyat güncellendi." : "Sepet Başarıyla Güncellendi.";
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
                    .Where(c => c.CustomerId == customerId && c.IsOrder == false)
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

                if (product is not null /*&& model.CustomerId.HasValue*/)
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

        public async Task<Response<PagedProductResponseDto>> GetProducts(int customerId, int? lastId, int pageSize)
        {
            Response<PagedProductResponseDto> response = new();
            try
            {
                pageSize = Math.Clamp(pageSize, 1, 50);

                // keyset sayfalama: skip yerine son gösterilen id'den devam edilir, pk index'i sayesinde her sayfa aynı hızda gelir.
                // "daha var mı" bilgisi için count sorgusu atmak yerine 1 fazla ürün çekilir
                var products = await _context.Products
                    .AsNoTracking()
                    .Where(p => lastId == null || p.ProductId > lastId)
                    .OrderBy(p => p.ProductId)
                    .Take(pageSize + 1)
                    .Select(p => new { p.ProductId, p.Name, p.Price, p.Score, p.ImagePath })
                    .ToListAsync();

                bool hasMore = products.Count > pageSize;
                if (hasMore)
                    products.RemoveAt(pageSize);

                // sadece bu sayfadaki ürünlerin favori bilgisi çekilir
                var productIds = products.Select(p => p.ProductId).ToList();
                var favorites = (await _context.Favorites
                    .AsNoTracking()
                    .Where(f => f.CustomerId == customerId && productIds.Contains(f.ProductId))
                    .Select(f => f.ProductId)
                    .ToListAsync()).ToHashSet();

                response.Result = new PagedProductResponseDto
                {
                    Products = [.. products.Select(p => new BasicProductResponseDto
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Price = p.Price,
                        Score = p.Score,
                        ImagePath = p.ImagePath,
                        IsFavorite = favorites.Contains(p.ProductId) // ürün favoriler arasında mı kontrolü
                    })],
                    HasMore = hasMore,
                    LastId = products.Count > 0 ? products[^1].ProductId : lastId
                };

                // boş liste hata değildir; sayfa boş durum mesajını gösterir
                response.Status = Status.Success;
                response.Message = products.Count > 0 ? "Ürünler başarıyla getirildi." : "Ürün bulunmadı.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetProducts ==> Error: {ex} ");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<string>> AddComment(AddCommentRequestDto model)
        {
            Response<string> response = new();
            response.Result = $"ProductId: {model.ProductId}";
            try
            {
                // müşteri var mı yok mu diye kontrol edilir
                if (!await _context.Customers.AnyAsync(c => c.CustomerId == model.CustomerId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Müşteri bulunamadı.";

                    return response;
                }

                // ürün var mı yok mu diye kontrol edilir
                if (!await _context.Products.AnyAsync(p => p.ProductId == model.ProductId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Ürün bulunamadı.";

                    return response;
                }

                // score olarak 1-5 arası değer mi gönderildiği kontrol edilir
                if (model.Score < 1 || model.Score > 5)
                {
                    response.Status = Status.Failed;
                    response.Message = "Score 1-5 arasında olmalıdır.";

                    return response;
                }

                // müşterinin ürünü daha öncesinde satın alıp almadığı kontrol edilir
                if (!await _context.OrderHistory.AnyAsync(o => o.ProductId == model.ProductId && o.CustomerId == model.CustomerId))
                {
                    response.Status = Status.Failed;
                    response.Message = "Yorum yapabilmek için ürünü satın almış olmalısınız.";

                    return response;
                }

                var comment = new Comments
                {
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId,
                    Comment = model.Comment,
                    Score = model.Score,
                    ImagePath = model.ImagePath,
                    CreatedAt = DateTime.Now
                };

                await _context.Comments.AddAsync(comment); // yorum tabloya eklenir
                await _context.SaveChangesAsync(); // değişiklikler kaydedilir

                // ürün puanını güncelle
                var updateScoreResponse = await UpdateProductScore(model.ProductId);
                if (updateScoreResponse.Status == Status.Success)
                {
                    response.Status = Status.Success;
                    response.Message = "Yorum başarıyla eklendi.";
                }
                else
                {
                    response.Status = Status.Error;
                    response.Message = "Yorum eklendi ancak ürün puanı güncellenemedi.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/AddComment ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<BasicProductResponseDto>>> SearchProductsByWithName(SearchProductByNameRequestDto model)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                var searchTerm = model.ProductName.Trim();
                // ürün adı veya açıklamayla sorgulat
                var products = await _context.Products
                    .Where(p => p.Name.Contains(searchTerm) || (p.Description != null && p.Description.Contains(searchTerm)) || (p.Brand != null && p.Brand.Name != null && p.Brand.Name.Contains(searchTerm)))
                    .Select(p => new { p.ProductId, p.Name, p.Price, p.Score, p.ImagePath })
                    .ToListAsync();

                // db'den kullanıcın favorilere attığı ürünlerin id'lerini çeker
                var favorites = await GetFavoritesIds(model.CustomerId, f => f.ProductId);

                response.Result = [.. products.Select(p => new BasicProductResponseDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Score = p.Score,
                    ImagePath = p.ImagePath,
                    IsFavorite = favorites.Contains(p.ProductId) // ürün favoriler arasında mı kontrolü
                })];
                response.Status = products.Count > 0 ? Status.Success : Status.Failed;
                response.Message = products.Count > 0 ? "Bulunan ürünler başarıyla getirildi." : "Aranan ürün bulunamadı";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/SearchProductsByWithName ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<BasicProductResponseDto>>> SearchProductsByWithCategory(SearchProductByCategoryRequestDto model)
        {
            Response<List<BasicProductResponseDto>> response = new();
            try
            {
                // ürün alt veya üst kategoriyle sorgulat
                var products = await _context.Products
                    .Where(p => model.CategoryIds!.Contains(p.SubCategoryId) || model.CategoryIds.Contains(p.SupCategoryId))
                    .Select(p => new { p.ProductId, p.Name, p.Price, p.Score, p.ImagePath })
                    .ToListAsync();

                // db'den kullanıcın favorilere attığı ürünlerin id'lerini çeker
                var favorites = await GetFavoritesIds(model.CustomerId, f => f.ProductId);

                response.Result = [.. products.Select(p => new BasicProductResponseDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Score = p.Score,
                    ImagePath = p.ImagePath,
                    IsFavorite = favorites.Contains(p.ProductId) // ürün favoriler arasında mı kontrolü
                })];
                response.Status = products.Count > 0 ? Status.Success : Status.Failed;
                response.Message = products.Count > 0 ? "Bulunan ürünler başarıyla getirildi." : "Aranan ürün bulunamadı";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/SearchProductsByWithCategory ==> Error: {ex}");
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
                    if (priceDiff > PriceTolerancePercent)
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

        public async Task<List<TResult>> GetFavoritesIds<TResult>(int customerId, Expression<Func<Favorites, TResult>> selector)
        {
            try
            {
                // db'den kullanıcın favorilere attığı ürünlerin selector'da gönderilen değerlerini çeker
                return await _context.Favorites
                    .Where(f => f.CustomerId == customerId)
                    .Select(selector)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetFavorites ==> Error: {ex}");
                return new List<TResult>();
            }
        }

        public async Task<Response<List<int>>> GetCategoryIds(string category)
        {
            Response<List<int>> response = new();
            try
            {
                var categories = await _context.ProductCategories
                    .Where(c => c.Name.Contains(category))
                    .Select(c => c.CategoryId)
                    .ToListAsync();

                if (categories.Count == 0)
                {
                    response.Status = Status.Default;
                    response.Message = "Aranan kategori bulunamadı.";
                    response.Result = categories;
                    return response;
                }
                response.Status = Status.Success;
                response.Message = "Aranan kategori(ler) bulundu.";
                response.Result = categories;
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

        public async Task<Response<List<CategoryMenuDto>>> GetCategoryMenu()
        {
            Response<List<CategoryMenuDto>> response = new();
            try
            {
                // kategori tablosunda üst-alt ilişkisi tutulmadığı için ilişki ürünlerdeki üst/alt kategori çiftlerinden çıkarılır
                var pairs = await _context.Products
                    .AsNoTracking()
                    .Select(p => new
                    {
                        SupId = p.SupCategoryId,
                        SupName = p.SupCategory.Name,
                        SubId = p.SubCategoryId,
                        SubName = p.SubCategory.Name
                    })
                    .Distinct()
                    .ToListAsync();

                response.Result = pairs
                    .GroupBy(p => new { p.SupId, p.SupName })
                    .Select(g => new CategoryMenuDto
                    {
                        CategoryId = g.Key.SupId,
                        Name = g.Key.SupName,
                        SubCategories = g
                            .Where(s => s.SubId != g.Key.SupId)
                            .Select(s => new SubCategoryMenuDto { CategoryId = s.SubId, Name = s.SubName })
                            .OrderBy(s => s.Name)
                            .ToList()
                    })
                    .OrderBy(c => c.CategoryId)
                    .ToList();

                response.Status = Status.Success;
                response.Message = "Kategori menüsü getirildi.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService/GetCategoryMenu ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        private async Task<Response<float?>> UpdateProductScore(int productId)
        {
            var response = new Response<float?>();
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product is null)
                {
                    response.Status = Status.Default;
                    response.Message = "Ürün bulunamadı.";
                    return response;
                }

                var scores = await _context.Comments
                    .Where(c => c.ProductId == productId)
                    .Select(c => c.Score!)
                    .ToListAsync();

                if (scores.Count == 0)
                {
                    response.Status = Status.Default;
                    response.Message = "Henüz yorum yok.";
                    return response;
                }

                product.Score = (float)scores.Average();
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                response.Status = Status.Success;
                response.Message = "Ürün puanı başarıyla güncellendi.";
                response.Result = product.Score;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ProductService/UpdateProductScore ==> Error: {ex}");
                _logger.LogError($"ProductService/UpdateProductScore ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}