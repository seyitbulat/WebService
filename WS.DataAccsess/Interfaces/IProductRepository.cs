using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IProductRepository:IBaseRepository<Product>
    {
         List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList);
         List<Product> GetByStockRange(short min, short max, params string[] includeList);
         Product GetById(int id, params string[] includeList);
        
    }
}
