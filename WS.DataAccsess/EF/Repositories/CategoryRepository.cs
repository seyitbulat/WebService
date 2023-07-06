using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, NorthwndContext>, ICategoryRepository
    {
        public List<Category> GetByDescription(string description, params string[] includeList)
        {
            return GetAll(c => c.Description.Contains(description), includeList);
        }

        public Category GetById(int id, params string[] includeList)
        {
            return Get(ctg => ctg.CategoryId == id, includeList);
        }
    }
}
