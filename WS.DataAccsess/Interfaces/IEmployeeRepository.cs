using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Employee GetById(int id);
        List<Employee> GetByCity(string city);
        List<Employee> GetByAgeRange(int min, int max);
    }
}
