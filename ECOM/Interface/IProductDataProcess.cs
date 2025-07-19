using ECOM.Data;
using ECOM.Models;

namespace ECOM.Interface
{
    public interface IProductDataProcess
    {
        Task<ProductDetailViewModel?> GetProductWithCommentsById(int id);
        Task<Product?> GetProductById(int id);
    }
}
