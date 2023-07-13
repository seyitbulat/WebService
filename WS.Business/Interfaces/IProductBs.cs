using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IProductBs
    {
        ApiResponse<List<ProductGetDto>> GetProducts(params string[] includeList);
        ApiResponse<List<ProductGetDto>> GetByPriceRange(decimal min, decimal max, params string[] includeList);
        ApiResponse<List<ProductGetDto>> GetByStockRange(short min, short max, params string[] includeList);


        ApiResponse<Product> AddProduct(ProductPostDto dto);
        ApiResponse<NoData> UpdateProduct(ProductPutDto dto);
        ApiResponse<Product> DeleteProduct(int ProductId);

        ApiResponse<ProductGetDto> GetById(int ProductId, params string[] includeList);
    }
}
