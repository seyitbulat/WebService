using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, NorthwndContext>, IProductRepository
    {
        public Product GetById(int id, params string[] includeList)
        {
            return Get(prd => prd.ProductId == id, includeList);
        }

        public List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            return GetAll(p => p.UnitPrice > min && p.UnitPrice < max, includeList);
        }

        public List<Product> GetByStockRange(short min, short max, params string[] includeList)
        {
            return GetAll(p => p.UnitsInStock > min && p.UnitsInStock < max, includeList);
        }
    }
}
