using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetByIdAsync(int id, params string[] includeList);
        Task<List<Order>> GetByOrderDateAsync(DateTime orderTime, params string[] includeList);


        Task<List<Order>> GetByEmployeeAsync(int employeeId, params string[] includeList);
        Task<List<Order>> GetByEmployeeAsync(string employeeName, params string[] includeList);

        Task<List<Order>> GetByCustomerAsync(string customerId, params string[] includeList);
        Task<List<Order>> GetByCustomerContactAsync(string contactName, params string[] includeList);

    }
}
