using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ISupplierBs
    {
        List<Supplier> GetSuppliers();
        List<Supplier> GetByCity(string city);
        List<Supplier> GetByCountry(string country);
        List<Supplier> GetByCompanyName(string companyName);
    }
}
