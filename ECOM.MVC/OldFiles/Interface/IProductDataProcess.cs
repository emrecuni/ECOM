using ECOM.Models;
using ECOM.MVC.OldFiles.Data;

namespace ECOM.MVC.OldFiles.Interface
{
    public interface IProductDataProcess
    {
        Task<ProductDetailViewModel?> GetProductWithCommentsById(int id);
        Task<Product?> GetProductById(int id);
    }
}
