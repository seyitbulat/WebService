using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order, NorthwndContext>, IOrderRepository
    {
        public async Task<Order> GetByIdAsync(int id)
        {
            return await GetAsync(o => o.OrderId == id);
        }
    }
}
