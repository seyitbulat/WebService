using Infrastructure.DataAccess.Implementations.EF;
using WS.DataAccsess.EF.Contexts;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccsess.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, NorthwndContext>, ICategoryRepository
    {
        public async Task<List<Category>> GetByDescriptionAsync(string description, params string[] includeList)
        {
            return await GetAllAsync(ctg => ctg.Description.Contains(description), includeList);
        }

        public async Task<Category> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(ctg => ctg.CategoryId == id, includeList);
        }
    }
}
