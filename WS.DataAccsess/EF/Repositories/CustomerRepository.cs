using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, NorthwndContext>, ICustomerRepository
    {
        public async Task<List<Customer>> GetByCityAsync(string city)
        {
            return await GetAllAsync(c => c.City == city);
        }

        public async Task<List<Customer>> GetByCompanyNameAsync(string companyName)
        {
            return await GetAllAsync(c => c.CompanyName == companyName);
        }

        public async Task<List<Customer>> GetByCountryAsync(string country)
        {
            return await GetAllAsync(c => c.Country == country);
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await GetAsync(c => c.CustomerId == id);
        }

        public async Task<List<Customer>> GetByPhoneAsync(string phone)
        {
            return await GetAllAsync(c => c.Phone == phone);
        }


    }
}
