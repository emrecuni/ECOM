using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;
using ECOM.Shared.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.MVC.ViewComponents
{
    // header'daki "Sepetim" butonunun üzerindeki ürün sayısı rozeti; layout her sayfada çağırır
    public class CartBadgeViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productService;
        private readonly ILogger<CartBadgeViewComponent> _logger;

        public CartBadgeViewComponent(IProductApiClient productService, ILogger<CartBadgeViewComponent> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = 0;

            // giriş yapılmamışsa sepet yoktur; rozet hiç gösterilmez
            if (User.Identity?.IsAuthenticated == true)
            {
                try
                {
                    var result = await _productService.GetCartAsync(UserClaimsPrincipal.GetCustomerId(), HttpContext.RequestAborted);

                    // api sepet boşken Status.Failed döner, bu durumda sayı 0 kalır
                    if (result is not null && result.IsSuccess && result.Data?.Status == Status.Success)
                        count = result.Data.Result?.Products?.Count ?? 0;
                }
                catch (Exception ex)
                {
                    // rozet gelmedi diye sayfa bozulmasın, sadece loglanır
                    _logger.LogError($"CartBadgeViewComponent Error => {ex}");
                }
            }

            return View(count);
        }
    }
}
