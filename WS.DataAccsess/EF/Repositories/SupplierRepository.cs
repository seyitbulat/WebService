using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, NorthwndContext>, ISupplierRepository
    {
        public List<Supplier> GetByCity(string city)
        {
            return GetAll(s => s.City == city);
        }

        public List<Supplier> GetByCompanyName(string companyName)
        {
            return GetAll(s => s.CompanyName == companyName);
        }

        public List<Supplier> GetByCountry(string country)
        {
            return GetAll(s => s.Country == country);
        }
    }
}
