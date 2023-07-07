using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class SupplierBs : ISupplierBs
    {
        private readonly ISupplierRepository _repo;

        public SupplierBs(ISupplierRepository repo)
        {
            _repo = repo;
        }

        public Supplier GetById(int id, params string[] includeList)
        {
            return _repo.GetById(id, includeList);
        }

        public List<Supplier> GetByCity(string city, params string[] includeList)
        {
            return _repo.GetByCity(city,includeList);
        }

        public List<Supplier> GetByCompanyName(string companyName, params string[] includeList)
        {
            return _repo.GetByCompanyName(companyName, includeList);
        }

        public List<Supplier> GetByCountry(string country, params string[] includeList)
        {
            return _repo.GetByCountry(country, includeList);
        }

        public List<Supplier> GetSuppliers(params string[] includeList)
        {
            return _repo.GetAll(includeList: includeList);
        }

        public void SaveNewSupplier(Supplier supplier)
        {
            _repo.Insert(supplier);
        }
    }
}
