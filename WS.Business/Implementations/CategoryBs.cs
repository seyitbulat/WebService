using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;

        public CategoryBs(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public void AddCategory(Category category)
        {
            _repo.Insert(category);
        }

        public List<Category> GetByDescription(string desc, params string[] includeList)
        {
            return _repo.GetByDescription(desc, includeList);
        }

        public Category GetById(int id, params string[] includeList)
        {
            return _repo.GetById(id, includeList);
        }

        public List<Category> GetCategories(params string[] includeList)
        {
            return _repo.GetAll(includeList: includeList);
        }
    }
}
