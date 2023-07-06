using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, NorthwndContext>, ICustomerRepository
    {
        public List<Customer> GetByCity(string city)
        {
            return GetAll(c => c.City == city);
        }

        public List<Customer> GetByCompanyName(string companyName)
        {
            return GetAll(c => c.CompanyName == companyName);
        }

        public List<Customer> GetByCountry(string country)
        {
            return GetAll(c => c.Country == country);
        }

        public Customer GetById(string id)
        {
            return Get(c => c.CustomerId == id);
        }

        public List<Customer> GetByPhone(string phone)
        {
            return GetAll(c => c.Phone == phone);
        }

  
    }
}
