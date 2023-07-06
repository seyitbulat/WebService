using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IEmployeeBs
    {
        Employee GetById(int id);
        List<Employee> GetEmployees();
        List<Employee> GetByAgeRange(int min, int max);
        void AddEmployee(Employee employee);
    }
}
