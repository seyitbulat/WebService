using Infrastructure.Utilities.ApiResponses;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ICategoryBs
    {
        ApiResponse<List<Category>> GetCategories(params string[] includeList);
        ApiResponse<List<Category>> GetByDescription(string desc, params string[] includeList);
        ApiResponse<Category> GetById(int id, params string[] includeList);
        ApiResponse<Category> AddCategory(Category category);
    }
}
