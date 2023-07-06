using Infrastructure.Model;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IProductBs
    {
        List<Product> GetProducts(params string[] includeList);
        List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList);
        List<Product> GetByStockRange(short min, short max, params string[] includeList);
        void AddProduct(Product product);
        Product GetById(int ProductId, params string[] includeList);
    }
}
