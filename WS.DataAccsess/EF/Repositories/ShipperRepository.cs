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
        public Shipper GetById(int id)
        {
            return Get(s => s.ShipperId == id);
        }

        public List<Shipper> GetByName(string name)
        {
            return GetAll(s => s.CompanyName == name);
        }

        public List<Shipper> GetByPhone(string phone)
        {
            return GetAll(s => s.Phone == phone);
        }
    }
}
