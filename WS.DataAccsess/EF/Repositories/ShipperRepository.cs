using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class ShipperRepository : BaseRepository<Shipper, NorthwndContext>, IShipperRepository
    {
        public async Task<Shipper> GetByIdAsync(int id)
        {
            return await GetAsync(s => s.ShipperId == id);
        }

        public async Task<List<Shipper>> GetByNameAsync(string name)
        {
            return await GetAllAsync(s => s.CompanyName == name);
        }

        public async Task<List<Shipper>> GetByPhoneAsync(string phone)
        {
            return await GetAllAsync(s => s.Phone == phone);
        }
    }
}
