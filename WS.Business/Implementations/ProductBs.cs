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


        public ApiResponse<ProductGetDto> GetById(int ProductId, params string[] includeList)
        {
            try
            {
                if (ProductId < 0)
                    throw new BadRequestException("Id degeri negatif olamaz");

                var product = _repo.GetById(ProductId, includeList);
                if (product != null)
                {
                    var dto = _mapper.Map<ProductGetDto>(product);
                    return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, dto);
                }
                throw new NotFoundException("Icerik bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<ProductGetDto>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                if (ex is NotFoundException)
                    return ApiResponse<ProductGetDto>.Fail(StatusCodes.Status404NotFound, ex.Message);

                return ApiResponse<ProductGetDto>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        public ApiResponse<List<ProductGetDto>> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            try
            {
                if (min > max && min > 0 && max > 0)
                    throw new BadRequestException("min, max'tan buyuk olamaz");

                if (min < 0 || max < 0)
                    throw new BadRequestException("min, max negatif deger alamaz");


                var products = _repo.GetByPriceRange(min, max, includeList);
                if (products != null && products.Count > 0)
                {
                    var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                    return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }

                throw new NotFoundException("Urun bulunamadi");


            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                if (ex is NotFoundException)
                    return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        public ApiResponse<List<ProductGetDto>> GetByStockRange(short min, short max, params string[] includeList)
        {
            try
            {
                if (min < 0 || max < 0)
                    throw new BadRequestException("min, max negatif deger alamaz");


                var products = _repo.GetByStockRange(min, max, includeList);
                if (products != null && products.Count > 0)
                {
                    var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                    return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }
                throw new NotFoundException("Urun bulunamadi");

            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                if (ex is BadRequestException)
                    return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<List<ProductGetDto>> GetProducts(params string[] includeList)
        {
            try
            {
                var products = _repo.GetAll(includeList: includeList);
                if (products.Count > 0)
                {
                    var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                    return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }
                throw new NotFoundException("Urun bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);
                return ApiResponse<List<ProductGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<Product> AddProduct(ProductPostDto dto)
        {
            try
            {
                if (dto == null)
                    throw new BadRequestException("Gönderilecek ürün bilgisi yollamalısınz");

                if (dto.UnitPrice < 0)
                    throw new BadRequestException("Fiyat 0'dan buyuk olmalidir");
                return ApiResponse<Product>.Fail(StatusCodes.Status404NotFound, "Fiyat 0'dan buyuk olmalidir");

                var product = _mapper.Map<Product>(dto);
                var insertedList = _repo.Insert(product);
                return ApiResponse<Product>.Success(StatusCodes.Status201Created, insertedList);
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<Product>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<Product>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<Product> DeleteProduct(int ProductId)
        {
            try
            {
                if (ProductId == null)
                    throw new BadRequestException("Id girmelisiniz");

                if (ProductId < 0)
                    throw new BadRequestException("Id negatif olamaz");

                var product = _repo.GetById(ProductId);
                _repo.Delete(product);
                return ApiResponse<Product>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<Product>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<Product>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<NoData> UpdateProduct(ProductPutDto dto)
        {
            try
            {
                if (dto == null)
                    throw new BadRequestException("Gönderilecek ürün bilgisi yollamalısınz");


                if (dto.UnitPrice < 0)
                    throw new BadRequestException("Fiyat 0'dan buyuk olmalidir");


                var product = _mapper.Map<Product>(dto);

                _repo.Update(product);

                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<NoData>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
