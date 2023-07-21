using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        Task<List<OrderDetail>> GetByIdAsync(int id, params string[] includeList);

        Task<List<OrderDetail>> GetByQuantityRangeAsync(short min, short max, params string[] includeList);
        Task<List<OrderDetail>> GetByUnitPriceRangeAsync(decimal min, decimal max, params string[] includeList);

        Task<List<OrderDetail>> GetByProductAsync(int id, params string[] includeList);
        Task<List<OrderDetail>> GetByProductAsync(string productName, params string[] includeList);

        Task<List<OrderDetail>> GetByCategoryAsync(int id, params string[] includeList);
        Task<List<OrderDetail>> GetByCategoryAsync(string categoryName, params string[] includeList);
    }
}
