using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;


namespace WS.Business.Interfaces
{
    public interface ICustomerBs
    {
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync();
        Task<ApiResponse<List<CustomerGetDto>>> GetByCityAsync(string city);
        Task<ApiResponse<List<CustomerGetDto>>> GetByCountryAsync(string country);
        Task<ApiResponse<List<CustomerGetDto>>> GetByPhoneAsync(string phone);
        Task<ApiResponse<CustomerGetDto>> GetByIdAsync(string id);

        Task<ApiResponse<Customer>> AddCustomerAsync(CustomerPostDto dto);
    }
}
