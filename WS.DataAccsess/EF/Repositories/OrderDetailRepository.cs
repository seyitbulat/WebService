using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail, NorthwndContext>, IOrderDetailRepository
    {
        public async Task<List<OrderDetail>> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAllAsync(od => od.OrderId == id, includeList);
        }

        public async Task<List<OrderDetail>> GetByQuantityRangeAsync(short min, short max, params string[] includeList)
        {
            return await GetAllAsync(od => od.Quantity > min && od.Quantity < max,includeList);
        }

        public async Task<List<OrderDetail>> GetByUnitPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(od => od.UnitPrice > min && od.UnitPrice < max, includeList);

        }


        public async Task<List<OrderDetail>> GetByProductAsync(int id, params string[] includeList)
        {
            return await GetAllAsync(od => od.ProductId == id,includeList);
        }
        public async Task<List<OrderDetail>> GetByProductAsync(string productName, params string[] includeList)
        {
            return await GetAllAsync(od => od.Product.ProductName.ToLower() == productName, includeList);
        }


        public async Task<List<OrderDetail>> GetByCategoryAsync(int id, params string[] includeList)
        {
            return await GetAllAsync(od => od.Product.CategoryId == id, includeList);
        }
        public async Task<List<OrderDetail>> GetByCategoryAsync(string categoryName, params string[] includeList)
        {
            return await GetAllAsync(od => od.Product.Category.CategoryName.ToLower() == categoryName, includeList);
        }
    }
}
