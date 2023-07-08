using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryBs(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ApiResponse<Category> AddCategory(CategoryPostDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _repo.Insert(category);
            return ApiResponse<Category>.Success(200, category);
        }

        public ApiResponse<List<CategoryGetDto>> GetByDescription(string desc, params string[] includeList)
        {
            var categories = _repo.GetByDescription(desc, includeList);
            if(categories.Count > 0)
            {
                var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                return ApiResponse<List<CategoryGetDto>>.Success(200, dtoList);
            }
            return null;
        }

        public ApiResponse<CategoryGetDto> GetById(int id, params string[] includeList)
        {
            var category = _repo.GetById(id, includeList);
            if (category != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(category);
                return ApiResponse<CategoryGetDto>.Success(200, dto);
            }
            return null;
        }

        public ApiResponse<List<CategoryGetDto>> GetCategories(params string[] includeList)
        {
            var categories = _repo.GetAll(includeList: includeList);
            if (categories.Count > 0)
            {
                var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                return ApiResponse<List<CategoryGetDto>>.Success(200, dtoList);
            }
            return null;
        }
    }
}
