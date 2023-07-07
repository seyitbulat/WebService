using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ISupplierBs
    {
        Supplier GetById(int id, params string[] includeList);
        List<Supplier> GetSuppliers(params string[] includeList);
        List<Supplier> GetByCity(string city, params string[] includeList);
        List<Supplier> GetByCountry(string country, params string[] includeList);
        List<Supplier> GetByCompanyName(string companyName, params string[] includeList);

        void SaveNewSupplier(Supplier supplier);
    }
}
