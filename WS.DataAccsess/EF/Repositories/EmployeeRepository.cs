using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, NorthwndContext>, IEmployeeRepository
    {
        public List<Employee> GetByAgeRange(int min, int max)
        {
            var current = DateTime.Now;
            return GetAll(e => (current.Year - e.BirthDate.Value.Year) > min && (current.Year - e.BirthDate.Value.Year) < max);
        }

        public List<Employee> GetByCity(string city)
        {
            return GetAll(e => e.City == city);
        }

        public Employee GetById(int id)
        {
            return Get(e => e.EmployeeId == id);
        }
    }
}
