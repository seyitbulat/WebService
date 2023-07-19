using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, NorthwndContext>, ISupplierRepository
    {
        public async Task<Supplier> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(s => s.SupplierId == id, includeList);
        }

        public async Task<List<Supplier>> GetByCityAsync(string city, params string[] includeList)
        {
            return await GetAllAsync(s => s.City == city, includeList);
        }

        public async Task<List<Supplier>> GetByCompanyNameAsync(string companyName, params string[] includeList)
        {
            return await GetAllAsync(s => s.CompanyName == companyName, includeList);
        }

        public async Task<List<Supplier>> GetByCountryAsync(string country, params string[] includeList)
        {
            return await GetAllAsync(s => s.Country == country, includeList);
        }
    }
}
