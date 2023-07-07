using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, NorthwndContext>, ISupplierRepository
    {
        public Supplier GetById(int id, params string[] includeList)
        {
            return Get(s => s.SupplierId == id, includeList);
        }

        public List<Supplier> GetByCity(string city, params string[] includeList)
        {
            return GetAll(s => s.City == city, includeList);
        }

        public List<Supplier> GetByCompanyName(string companyName, params string[] includeList)
        {
            return GetAll(s => s.CompanyName == companyName, includeList);
        }

        public List<Supplier> GetByCountry(string country, params string[] includeList)
        {
            return GetAll(s => s.Country == country, includeList);
        }
    }
}
