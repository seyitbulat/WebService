using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IShipperRepository:IBaseRepository<Shipper>
    {
        Task<Shipper> GetByIdAsync(int id);
        Task<List<Shipper>> GetByNameAsync(string name);
        Task<List<Shipper>> GetByPhoneAsync(string phone);
    }
}
