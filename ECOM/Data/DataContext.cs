using Microsoft.EntityFrameworkCore;

namespace ECOM.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }        
    }
}
