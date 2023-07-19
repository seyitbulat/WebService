using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
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
            try
            {
                var category = _mapper.Map<Category>(dto);
                if (dto == null)
                    throw new BadRequestException("Gonderilecek kategori bilgisi yollamalisiniz");

                var insertedCategory = _repo.Insert(category);
                return ApiResponse<Category>.Success(200, insertedCategory);
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<Category>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<Category>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<List<CategoryGetDto>> GetByDescription(string desc, params string[] includeList)
        {
            try
            {
                if (desc != null)
                    throw new BadRequestException("Bir desc icerigi girmelisiniz");

                var categories = _repo.GetByDescription(desc, includeList);
                if (categories.Count > 0)
                {
                    var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                    return ApiResponse<List<CategoryGetDto>>.Success(200, dtoList);
                }
                throw new NotFoundException("Gosterilecek kategori biligisi bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                if (ex is NotFoundException)
                    return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        public ApiResponse<CategoryGetDto> GetById(int id, params string[] includeList)
        {
            try
            {
                var category = _repo.GetById(id, includeList);
                if (category != null)
                {
                    var dto = _mapper.Map<CategoryGetDto>(category);
                    return ApiResponse<CategoryGetDto>.Success(200, dto);
                }
                throw new NotFoundException("Gosterilecek kategori bilgisi bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<CategoryGetDto>.Fail(StatusCodes.Status404NotFound, ex.Message);

                return ApiResponse<CategoryGetDto>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<List<CategoryGetDto>> GetCategories(params string[] includeList)
        {
            try
            {
                var categories = _repo.GetAll(includeList: includeList);
                if (categories.Count > 0)
                {
                    var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                    return ApiResponse<List<CategoryGetDto>>.Success(200, dtoList);
                }
                throw new NotFoundException("Gosterilecek kategori bilgisi bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);
                return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
