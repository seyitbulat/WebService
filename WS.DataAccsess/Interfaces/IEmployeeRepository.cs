using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetByCityAsync(string city);
        Task<List<Employee>> GetByAgeRangeAsync(int min, int max);
        //Task<List<Employee>> GetByNameAsync(string name);
    }
}
