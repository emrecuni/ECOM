using ECOM.Models;

namespace ECOM.Interface
{
    public interface IProductDataProcess
    {
        Task<ProductDetailViewModel?> GetProduct(int id);        
    }
}
