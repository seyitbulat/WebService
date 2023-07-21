using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<Category> GetByIdAsync(int id, params string[] includeList);
        Task<List<Category>> GetByDescriptionAsync(string description, params string[] includeList);
        Task<List<Category>> GetByNameAsync(string name, params string[] includeList);
    }
}
