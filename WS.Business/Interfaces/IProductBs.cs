using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IProductBs
    {
        Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetByStockRangeAsync(short min, short max, params string[] includeList);


        Task<ApiResponse<Product>> AddProductAsync(ProductPostDto dto);
        Task<ApiResponse<NoData>> UpdateProductAsync(ProductPutDto dto);
        Task<ApiResponse<Product>> DeleteProductAsync(int ProductId);

        Task<ApiResponse<ProductGetDto>> GetByIdAsync(int ProductId, params string[] includeList);
    }
}
