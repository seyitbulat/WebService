using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IEmployeeRepository _repo;

        public Employee GetById(int id)
        {
            return _repo.GetById(id);
        }

        public EmployeeBs(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public List<Employee> GetByAgeRange(int min, int max)
        {
            return _repo.GetByAgeRange(min, max);
        }

        public List<Employee> GetEmployees()
        {
            return _repo.GetAll();
        }

        public void AddEmployee(Employee employee)
        {
             _repo.Insert(employee);
        }
    }
}
