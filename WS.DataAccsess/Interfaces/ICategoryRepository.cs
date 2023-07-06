using Infrastructure.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.Interfaces
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        List<Category> GetByDescription(string description, params string[] includeList);
        Category GetById(int id, params string[] includeList);
    }
}
