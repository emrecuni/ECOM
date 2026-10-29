using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs.Product;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ECOM.MVC.ViewComponents
{
    // header'daki kategori çubuğu; üst kategorilerin hover'ında alt kategorileri gösterir
    public class CategoryMenuViewComponent : ViewComponent
    {
        private const string CacheKey = "CategoryMenu";

        private readonly IProductApiClient _productService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CategoryMenuViewComponent> _logger;

        public CategoryMenuViewComponent(IProductApiClient productService, IMemoryCache cache, ILogger<CategoryMenuViewComponent> logger)
        {
            _productService = productService;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // kategoriler nadiren değiştiği için her sayfa açılışında api'ye gitmemek adına önbellekte tutulur
            if (!_cache.TryGetValue(CacheKey, out List<CategoryMenuDto>? menu))
            {
                menu = [];
                try
                {
                    var result = await _productService.GetCategoryMenuAsync(HttpContext.RequestAborted);

                    if (result.IsSuccess && result.Data?.Status == Status.Success && result.Data.Result is not null)
                    {
                        menu = result.Data.Result;
                        _cache.Set(CacheKey, menu, TimeSpan.FromMinutes(10)); // hata durumunda önbelleğe yazılmaz, sonraki istekte tekrar denenir
                    }
                }
                catch (Exception ex)
                {
                    // alt kategoriler gelmese de üst kategori linkleri çalışmaya devam eder
                    _logger.LogError($"CategoryMenuViewComponent Error => {ex}");
                }
            }

            return View(menu);
        }
    }
}
