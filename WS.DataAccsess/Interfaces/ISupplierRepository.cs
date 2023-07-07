using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Supplier GetById(int id, params string[] includeList);
        List<Supplier> GetByCity(string city, params string[] includeList);
        List<Supplier> GetByCountry(string country, params string[] includeList);
        List<Supplier> GetByCompanyName(string companyName, params string[] includeList);
    }
}
