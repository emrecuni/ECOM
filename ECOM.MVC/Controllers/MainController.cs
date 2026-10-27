
using ECOM.Models;
using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;
using ECOM.MVC.OldFiles.Data;
using ECOM.MVC.OldFiles.DTO;
using ECOM.MVC.OldFiles.Services;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class MainController : Controller
    {
        private readonly IProductApiClient _productService;
        private readonly ICustomerApiClient _customerService;
        private readonly DataContext _context;
        private readonly ILogger<MainController> _logger;

        public MainController(IProductApiClient productService, ICustomerApiClient customerService, DataContext context, ILogger<MainController> logger)
        {
            _productService = productService;
            _customerService = customerService;
            _context = context;
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var result = await _productService.GetAllProductsAsync(User.GetCustomerId(), ct);

            if (result is null)
            {
                ErrorViewModel error = new()
                {
                    RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Message: Ürünler çekilirken bir hata oluştu.",
                    Title = "Giriş Yapılırken Bir Hata Oluştu."
                };
                _logger.LogError($"Main/Index Error ");
                return View("Error", error);
            }
            else if (!result.IsSuccess)
            {
                ErrorViewModel error = new()
                {
                    RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = $"Message: {result.ErrorMessage}",
                    Title = "Giriş Yapılırken Bir Hata Oluştu."
                };
                _logger.LogError($"Main/Index Error ");
                return View("Error", error);
            }
            else if (result.Data is not null && result.Data.Status != Status.Success)
            {
                ErrorViewModel error = new()
                {
                    RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = $"Message: {result.Data.Message}",
                    Title = "Giriş Yapılırken Bir Hata Oluştu."
                };
                _logger.LogError($"Main/Index Error ");
                return View("Error", error);
            }
            return View(result!.Data!.Result);
        }

        [Authorize]
        public async Task<IActionResult> ProductsByCategoryName(string category, CancellationToken ct)
        {
            try
            {
                var categoryResult = await _productService.GetCategoryIdsAsync(category, ct);

                if (!categoryResult.IsSuccess || categoryResult.Data?.Status != Status.Success || categoryResult.Data.Result is null || categoryResult.Data.Result.Count == 0)
                    return RedirectToAction("Index");

                var result = await _productService.SearchProductsByWithCategory(new SearchProductByCategoryRequestDto
                {
                    CustomerId = User.GetCustomerId(),
                    CategoryIds = categoryResult?.Data?.Result
                }, ct);

                if (result.IsSuccess && result.Data?.Status == Status.Success)
                    return View("Index", result.Data.Result);
                else
                {
                    ErrorViewModel error = new()
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Message = $"Message: {result.ErrorMessage}",
                        Title = "Ürünler getirilirken bir hata oluştu."
                    };
                    _logger.LogError($"Main/ProductsByCategoryName Error ");
                    return View("Error", error);
                }
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"ProductsByCategoryName Error => {ex}");
                return View();
            }
        }

        public async Task<IActionResult> ProductsByCategoryId(int id, CancellationToken ct)
        {
            try
            {
                if (id == 0) // buradaki kontrolü geliştir
                    return View("Index");

                var result = await _productService.SearchProductsByWithCategory(new SearchProductByCategoryRequestDto
                {
                    CategoryIds = new List<int> { id },
                    CustomerId = User.GetCustomerId()
                }, ct);

                if (result.IsSuccess && result.Data?.Status == Status.Success)
                    return View("Index", result.Data.Result);
                else
                {
                    ErrorViewModel error = new()
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Message = $"Message: {result.ErrorMessage}",
                        Title = "Ürünler getirilirken bir hata oluştu."
                    };
                    _logger.LogError($"Main/ProductsByCategoryId Error ");
                    return View("Error", error);
                }
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"ProductsByCategoryId Error => {ex}");
                return View("Index");
            }
        }

        public async Task<IActionResult> SearchProductByName(string category, CancellationToken ct)
        {
            try
            {
                if (category is null)
                    return View("Index");

                var categoryResult = await _productService.GetCategoryIdsAsync(category, ct);

                if (!categoryResult.IsSuccess || categoryResult.Data?.Status != Status.Success || categoryResult.Data.Result is null || categoryResult.Data.Result.Count == 0)
                    return RedirectToAction("Index");

                var result = await _productService.SearchProductsByWithCategory(new SearchProductByCategoryRequestDto
                {
                    CustomerId = User.GetCustomerId(),
                    CategoryIds = categoryResult?.Data?.Result
                }, ct);

                if (result.IsSuccess && result.Data?.Status == Status.Success)
                    return View("Index", result.Data.Result);
                else
                {
                    ErrorViewModel error = new()
                    {
                        RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Message = $"Message: {result.ErrorMessage}",
                        Title = "Ürünler getirilirken bir hata oluştu."
                    };
                    _logger.LogError($"Main/SearchProductByName Error ");
                    return View("Error", error);
                }
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"SearchProductByName Error => {ex}");
                return View("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Favorite(int id, CancellationToken ct)
        {
            try
            {
                var favoriteResult = await _customerService.GetFavoritesAsync(User.GetCustomerId(), ct);

                if (!favoriteResult.IsSuccess || favoriteResult.Data?.Status != Status.Success)
                    return StatusCode(StatusCodes.Status502BadGateway, new { message = favoriteResult.Data?.Message ?? favoriteResult.ErrorMessage ?? "Favoriler getirilemedi." }); // ajax success'e düşüp kalbin durumunu bozmasın

                if (favoriteResult.Data.Result?.Any(f => f.ProductId == id) == true)
                {
                    var removeResult = await _customerService.RemoveFavoriteAsync(new FavoriteRequestDto
                    {
                        CustomerId = User.GetCustomerId(),
                        ProductId = id
                    }, ct);
                    if (removeResult.IsSuccess && removeResult.Data?.Status == Status.Success)
                        return Json(new { isFavorite = false });
                    else
                        return Json(new { isFavorite = true });
                }
                else
                {
                    var addResult = await _customerService.AddFavoriteAsync(new FavoriteRequestDto
                    {
                        CustomerId = User.GetCustomerId(),
                        ProductId = id
                    }, ct);
                    if (addResult.IsSuccess && addResult.Data?.Status == Status.Success)
                        return Json(new { isFavorite = true });
                    else
                        return Json(new { isFavorite = false });
                }
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                ErrorViewModel error = new ErrorViewModel
                {
                    Message = "Hesap bilgileri getirilirken bir hata oluştu.",
                    RequestId = HttpContext.TraceIdentifier,
                    Title = $"Hata Kodu: {guid}"
                };
                _logger.LogError($"Main/Favorite Error Hata Kodu: {guid} => {ex}");
                return View("Error", error);
            }
        }
    }
}
