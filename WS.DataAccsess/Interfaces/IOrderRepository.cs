using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetByIdAsync(int id);
    }
}
