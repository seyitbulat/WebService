using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        List<Customer> GetByCompanyName(string companyName);
        List<Customer> GetByCity(string city);
        List<Customer> GetByCountry(string country);
        List<Customer> GetByPhone(string phone);
        Customer GetById(string id);
    }
}
