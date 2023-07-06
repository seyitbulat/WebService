using WS.Model.Entities;


namespace WS.Business.Interfaces
{
    public interface ICustomerBs
    {
        List<Customer> GetCustomers();
        List<Customer> GetByCity(string city);
        List<Customer> GetByCountry(string country);
        List<Customer> GetByPhone(string phone);
        void AddCustomer(Customer customer);
        Customer GetById(string id);
    }
}
