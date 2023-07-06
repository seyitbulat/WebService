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

        public List<Supplier> GetByCity(string city)
        {
            return _repo.GetByCity(city);
        }

        public List<Supplier> GetByCompanyName(string companyName)
        {
            return _repo.GetByCompanyName(companyName);
        }

        public List<Supplier> GetByCountry(string country)
        {
            return _repo.GetByCountry(country);
        }

        public List<Supplier> GetSuppliers()
        {
            return _repo.GetAll();
        }
    }
}
