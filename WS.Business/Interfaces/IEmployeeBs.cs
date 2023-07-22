using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IEmployeeBs
    {
        Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int id);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync();
        Task<ApiResponse<List<EmployeeGetDto>>> GetByAgeRangeAsync(int min, int max);


        Task<ApiResponse<Employee>> AddEmployeeAsync(EmployeePostDto dto);
    }
}
