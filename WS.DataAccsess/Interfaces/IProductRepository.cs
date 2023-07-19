using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IProductRepository:IBaseRepository<Product>
    {
         Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList);
         Task<List<Product>> GetByStockRangeAsync(short min, short max, params string[] includeList);
         Task<Product> GetByIdAsync(int id, params string[] includeList);
        
    }
}
