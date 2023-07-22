using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Task<Supplier> GetByIdAsync(int id, params string[] includeList);
        Task<List<Supplier>> GetByCityAsync(string city, params string[] includeList);
        Task<List<Supplier>> GetByCountryAsync(string country, params string[] includeList);
        Task<List<Supplier>> GetByCompanyNameAsync(string companyName, params string[] includeList);
    }
}
