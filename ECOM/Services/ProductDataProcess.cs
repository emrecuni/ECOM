using ECOM.Data;
using ECOM.Interface;
using ECOM.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECOM.Services
{
    public class ProductDataProcess : IProductDataProcess
    {
        private readonly DataContext _context;

        public ProductDataProcess(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductDetailViewModel?> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.SupCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.ProductId == id);

                List<Comments> comments = new();

                if (product is not null) // ürün db'de varsa yorumları çekilir
                    comments = await _context.Comments
                       .Include(c => c.Product)
                       .Include(c => c.Customer)
                       .Where(p => p.ProductId == id)
                       .ToListAsync();

                ProductDetailViewModel viewModel = new()
                {
                    Product = product,
                    Comments = comments
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"GetProduct Error => {ex}");
                return null;
            }
        }
    }
}
