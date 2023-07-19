using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;


namespace WS.Business.Interfaces
{
    public interface ICustomerBs
    {
        ApiResponse<List<CustomerGetDto>> GetCustomers();
        ApiResponse<List<CustomerGetDto>> GetByCity(string city);
        ApiResponse<List<CustomerGetDto>> GetByCountry(string country);
        ApiResponse<List<CustomerGetDto>> GetByPhone(string phone);
        ApiResponse<CustomerGetDto> GetById(string id);

        ApiResponse<Customer> AddCustomer(CustomerPostDto dto);
    }
}
