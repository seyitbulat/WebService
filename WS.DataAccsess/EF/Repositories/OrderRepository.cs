using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order, NorthwndContext>, IOrderRepository
    {
        public async Task<Order> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(o => o.OrderId == id, includeList);
        }
        public async Task<List<Order>> GetByOrderDateAsync(DateTime orderTime, params string[] includeList)
        {
            return await GetAllAsync(o => o.OrderDate == orderTime);
        }


        public async Task<List<Order>> GetByEmployeeAsync(int employeeId, params string[] includeList)
        {
            return await GetAllAsync(o => o.EmployeeId == employeeId, includeList);
        }
        public async Task<List<Order>> GetByEmployeeAsync(string employeeName, params string[] includeList)
        {
            return await GetAllAsync(o => o.Employee.LastName.ToLower() == employeeName.ToLower(), includeList);
        }

        public async Task<List<Order>> GetByCustomerAsync(string customerId, params string[] includeList)
        {
            return await GetAllAsync(o => o.CustomerId == customerId, includeList);
        }
        public async Task<List<Order>> GetByCustomerContactAsync(string contactName, params string[] includeList)
        {
            return await GetAllAsync(o => o.Customer.ContactName.ToLower() == contactName.ToLower(), includeList);
        }

    }
}
