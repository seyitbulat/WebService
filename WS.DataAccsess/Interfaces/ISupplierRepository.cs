using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        List<Supplier> GetByCity(string city);
        List<Supplier> GetByCountry(string country);
        List<Supplier> GetByCompanyName(string companyName);
    }
}
