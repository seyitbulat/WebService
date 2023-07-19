using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetByDescriptionAsync(string desc, params string[] includeList);
        Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int id, params string[] includeList);

        Task<ApiResponse<Category>> AddCategoryAsync(CategoryPostDto dto);
    }
}
