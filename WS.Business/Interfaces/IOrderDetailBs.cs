using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Dtos.OrderDetail;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IOrderDetailBs
    {
        Task<ApiResponse<List<OrderDetailGetDto>>> GetOrderDetailByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<OrderDetailGetDto>>> GetOrderDetailsAsync(params string[] includeList);

        Task<ApiResponse<List<OrderDetailGetDto>>> GetByQuantityRangeAsync(short min, short max, params string[] includeList);
        Task<ApiResponse<List<OrderDetailGetDto>>> GetByUnitPriceRangeAsync(decimal min, decimal max, params string[] includeList);

        Task<ApiResponse<List<OrderDetailGetDto>>> GetByProductAsync(int productId, params string[] includeList);
        Task<ApiResponse<List<OrderDetailGetDto>>> GetByProductAsync(string productName, params string[] includeList);

        Task<ApiResponse<List<OrderDetailGetDto>>> GetByCategoryAsync(int categoryId, params string[] includeList);
        Task<ApiResponse<List<OrderDetailGetDto>>> GetByCategoryAsync(string categoryName, params string[] includeList);
    }
}
