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

        public async Task<ApiResponse<Category>> AddCategoryAsync(CategoryPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Gonderilecek kategori bilgisi yollamalisiniz");
            var category = _mapper.Map<Category>(dto);
            var insertedCategory = await _repo.InsertAsync(category);
            return ApiResponse<Category>.Success(200, insertedCategory);


        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetByDescriptionAsync(string desc, params string[] includeList)
        {

            if (desc != null)
                throw new BadRequestException("Bir desc icerigi girmelisiniz");

            var categories = await _repo.GetByDescriptionAsync(desc, includeList);
            if (categories.Count > 0)
            {
                var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                return ApiResponse<List<CategoryGetDto>>.Success(200, dtoList);
            }
            throw new NotFoundException("Gosterilecek kategori biligisi bulunamadi");

        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int id, params string[] includeList)
        {

            var category = await _repo.GetByIdAsync(id, includeList);
            if (category != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(category);
                return ApiResponse<CategoryGetDto>.Success(200, dto);
            }
            throw new NotFoundException("Gosterilecek kategori bilgisi bulunamadi");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList)
        {

            var categories = await _repo.GetAllAsync(includeList: includeList);
            if (categories.Count > 0)
            {
                var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                return ApiResponse<List<CategoryGetDto>>.Success(200, dtoList);
            }
            throw new NotFoundException("Gosterilecek kategori bilgisi bulunamadi");

        }

        public async Task<ApiResponse<NoData>> UpdateCategoryAsync(CategoryPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Gonderilecek kategori bilgisi yollamalisiniz");

            if (dto.CategoryId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var category = _mapper.Map<Category>(dto);
            await _repo.UpdateAsync(category);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> DeleteCategoryAsync(int id)
        {
            if (id == null)
                throw new BadRequestException("Gönderilecek kategori bilgisi yollamalısınz");

            if (id < 0)
                throw new BadRequestException("Id negatif olamaz");

            var category = await _repo.GetByIdAsync(id);
            if(category != null)
            {
                await _repo.DeleteAsync(category);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Silinecek kategori bulunamadi");
        }
    }
}
