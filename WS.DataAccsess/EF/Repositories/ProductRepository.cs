using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, NorthwndContext>, IProductRepository
    {
        public async Task<Product> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.ProductId == id, includeList);
        }

        public async Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(p => p.UnitPrice > min && p.UnitPrice < max, includeList);
        }

        public async Task<List<Product>> GetByStockRangeAsync(short min, short max, params string[] includeList)
        {
            return await GetAllAsync(p => p.UnitsInStock > min && p.UnitsInStock < max, includeList);
        }
    }
}
