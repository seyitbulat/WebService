using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        Task<List<Customer>> GetByCompanyNameAsync(string companyName);
        Task<List<Customer>> GetByCityAsync(string city);
        Task<List<Customer>> GetByCountryAsync(string country);
        Task<List<Customer>> GetByPhoneAsync(string phone);
        Task<Customer> GetByIdAsync(string id);
    }
}
