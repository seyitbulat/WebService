using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, NorthwndContext>, IEmployeeRepository
    {
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await GetAsync(e => e.EmployeeId == id);
        }

        public async Task<List<Employee>> GetByCityAsync(string city)
        {
            return await GetAllAsync(e => e.City == city);
        }

        public async Task<List<Employee>> GetByAgeRangeAsync(int min, int max)
        {
            var current = DateTime.Now;
            return await GetAllAsync(e => (current.Year - e.BirthDate.Value.Year) > min && (current.Year - e.BirthDate.Value.Year) < max);
        }
    }
}
