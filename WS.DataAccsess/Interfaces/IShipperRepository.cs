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
        Shipper GetById(int id);
        List<Shipper> GetByName(string name);
        List<Shipper> GetByPhone(string phone);
    }
}
