using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Dtos.Order;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IOrderBs
    {
        Task<ApiResponse<OrderGetDto>> GetByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrders(params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByOrderDateAsync(DateTime orderTime, params string[] includeList);


        Task<ApiResponse<List<OrderGetDto>>> GetByEmployeeAsync(int employeeId, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByEmployeeAsync(string employeeName, params string[] includeList);

        Task<ApiResponse<List<OrderGetDto>>> GetByCustomerAsync(string customerId, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetByCustomerContactAsync(string contactName, params string[] includeList);
    }
}
