using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ICategoryBs
    {
        ApiResponse<List<CategoryGetDto>> GetCategories(params string[] includeList);
        ApiResponse<List<CategoryGetDto>> GetByDescription(string desc, params string[] includeList);
        ApiResponse<CategoryGetDto> GetById(int id, params string[] includeList);

        ApiResponse<Category> AddCategory(CategoryPostDto dto);
    }
}
