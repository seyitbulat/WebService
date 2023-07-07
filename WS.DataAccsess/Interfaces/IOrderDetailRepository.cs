using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IOrderDetailRepository:IBaseRepository<OrderDetail>
    {
    }
}
