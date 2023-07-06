using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class CustomerBs : ICustomerBs
    {
        private readonly ICustomerRepository _repo;

        public CustomerBs(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public Customer GetById(string id)
        {
            return _repo.GetById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _repo.Insert(customer);
        }

        public List<Customer> GetByCity(string city)
        {
            return _repo.GetByCity(city);
        }

        public List<Customer> GetByCountry(string country)
        {
            return _repo.GetByCountry(country);
        }

        public List<Customer> GetByPhone(string phone)
        {
            return _repo.GetByPhone(phone);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetAll();
        }
    }
}
