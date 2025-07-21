using ECOM.Data;
using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value); // giriş yapan kullanıcının id'sini alır

            var carts = await _context.Carts
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .Include(c => c.Seller)
                .Include(c => c.Coupon)
                .Where(c => c.CustomerId == customerId && c.Enable == true)
                .ToListAsync();


            CartViewModel cartViewModel = new()
            {
                Carts = carts,
                Favorites = await _context.Favorites
                    .Include(f => f.Product)
                    .Where(f => f.CustomerId == customerId)
                    .ToListAsync()
            };

            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] CartStatusModel model) // sepetteki ürünün statüsünü günceller
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == model.CartId);

                if (cart is null)
                    return NotFound();

                cart.Enable = model.IsActive;// veri tabanından çekilen ürünün statüsüne modelden gelen değer yazılır

                _context.Carts.Update(cart); // değer güncellenir
                await _context.SaveChangesAsync(); // veri tabanına kaydedilir

                return Ok();
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"UpdateStatus Error => {ex}");
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartQuantityModel model) // sepetteki ürünün adedini günceller
        {
            try
            {
                var cart = await _context.Carts
                    .Include(c=> c.Product)
                    .FirstOrDefaultAsync(c => c.CartId == model.CartId); // ilgili ürünü veri tabanından çekilir

                if (cart is null)
                    return NotFound();

                cart.Piece = model.Piece; // veri tabanından çekilen ürünün adedine modelden gelen değer yazılır
                cart.TotalPrice = (decimal)cart.Product.Price! * model.Piece; // toplam fiyat güncellenir

                _context.Carts.Update(cart); // değer güncellenir
                await _context.SaveChangesAsync(); // veri tabanına kaydedilir

                return Json(new { totalPrice = cart.TotalPrice.ToString("F2") });
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"UpdateQuantity Error => {ex}");
                return View("Error");
            }
        }
    }
}
