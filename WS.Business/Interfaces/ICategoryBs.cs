using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ICategoryBs
    {
        List<Category> GetCategories(params string[] includeList);
        List<Category> GetByDescription(string desc, params string[] includeList);
        Category GetById(int id, params string[] includeList);
        void AddCategory(Category category);
    }
}
