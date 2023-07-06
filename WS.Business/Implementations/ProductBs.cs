using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _repo;

        public ProductBs(IProductRepository repo)
        {
            _repo = repo;
        }

        public void AddProduct(Product product)
        {
            _repo.Insert(product);
        }

        public Product GetById(int ProductId, params string[] includeList)
        {
            return _repo.GetById(ProductId, includeList);
        }

        public List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            return _repo.GetByPriceRange(min, max, includeList);
        }

        public List<Product> GetByStockRange(short min, short max, params string[] includeList)
        {
            return _repo.GetByStockRange(min, max, includeList);
        }

        public List<Product> GetProducts(params string[] includeList)
        {
            return _repo.GetAll(includeList: includeList);
        }
    }
}
