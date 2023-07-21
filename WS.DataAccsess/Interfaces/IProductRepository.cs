using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByIdAsync(int id, params string[] includeList);
        Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList);
        Task<List<Product>> GetByStockRangeAsync(short min, short max, params string[] includeList);

        Task<List<Product>> GetByCategoryAsync(int categoryId, params string[] includeList);
        Task<List<Product>> GetByCategoryAsync(string categoryName, params string[] includeList);

        Task<List<Product>> GetBySupplierAsync(int supplierId, params string[] includeList);
        Task<List<Product>> GetBySupplierAsync(string supplierCompanyName, params string[] includeList);

    }
}
