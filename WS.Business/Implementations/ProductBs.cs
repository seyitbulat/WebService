using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductBs(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<ApiResponse<ProductGetDto>> GetByIdAsync(int ProductId, params string[] includeList)
        {

            if (ProductId < 0)
                throw new BadRequestException("Id degeri negatif olamaz");

            var product = await _repo.GetByIdAsync(ProductId, includeList);
            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");


        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList)
        {

            var products = await _repo.GetAllAsync(includeList: includeList);
            if (products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Urun bulunamadi");


        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {

            if (min > max && min > 0 && max > 0)
                throw new BadRequestException("min, max'tan buyuk olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("min, max negatif deger alamaz");


            var products = await _repo.GetByPriceRangeAsync(min, max, includeList);
            if (products != null && products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }

            throw new NotFoundException("Urun bulunamadi");


        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByStockRangeAsync(short min, short max, params string[] includeList)
        {

            if (min < 0 || max < 0)
                throw new BadRequestException("min, max negatif deger alamaz");

            var products = await _repo.GetByStockRangeAsync(min, max, includeList);

            if (products != null && products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Urun bulunamadi");


        }


        public async Task<ApiResponse<List<ProductGetDto>>> GetByCategoryAsync(int categoryId, params string[] includeList)
        {
            if (categoryId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var products = await _repo.GetByCategoryAsync(categoryId, includeList);
            if (products != null && products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Urun bulunamadi");
        }
        public async Task<ApiResponse<List<ProductGetDto>>> GetByCategoryAsync(string categoryName, params string[] includeList)
        {
            if (categoryName == null)
                throw new BadRequestException("categoryName degeri girin");

            var products = await _repo.GetByCategoryAsync(categoryName, includeList);
            if (products != null && products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Urun bulunamadi");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetBySupplierAsync(int supplierId, params string[] includeList)
        {
            if (supplierId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var products = await _repo.GetByCategoryAsync(supplierId, includeList);
            if (products != null && products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Urun bulunamadi");

        }
        public async Task<ApiResponse<List<ProductGetDto>>> GetBySupplierAsync(string supplierCompanyName, params string[] includeList)
        {
            if (supplierCompanyName == null)
                throw new BadRequestException("categoryName degeri girin");

            var products = await _repo.GetByCategoryAsync(supplierCompanyName, includeList);
            if (products != null && products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Urun bulunamadi");
        }


        public async Task<ApiResponse<Product>> AddProductAsync(ProductPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Gönderilecek ürün bilgisi yollamalısınz");

            if (dto.UnitPrice < 0)
                throw new BadRequestException("Fiyat 0'dan buyuk olmalidir");

            var product = _mapper.Map<Product>(dto);
            var insertedList = await _repo.InsertAsync(product);
            return ApiResponse<Product>.Success(StatusCodes.Status201Created, insertedList);
        }

        public async Task<ApiResponse<NoData>> DeleteProductAsync(int ProductId)
        {

            if (ProductId == null)
                throw new BadRequestException("Id girmelisiniz");

            if (ProductId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var product = await _repo.GetByIdAsync(ProductId);
            
            if(product != null)
            {
                await _repo.DeleteAsync(product);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Silinecek urun bulunamadi");
        }

        public async Task<ApiResponse<NoData>> UpdateProductAsync(ProductPutDto dto)
        {

            if (dto == null)
                throw new BadRequestException("Gönderilecek ürün bilgisi yollamalısınz");


            if (dto.UnitPrice < 0)
                throw new BadRequestException("Fiyat 0'dan buyuk olmalidir");


            var product = _mapper.Map<Product>(dto);

            await _repo.UpdateAsync(product);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
    }
}
