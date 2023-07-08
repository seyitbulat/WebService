using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
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

        public ApiResponse<Product> AddProduct(ProductPostDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            _repo.Insert(product);
            return ApiResponse<Product>.Success(200, product);
        }

        public ApiResponse<Product> DeleteProduct(int ProductId)
        {
            var product = _repo.GetById(ProductId);
            _repo.Delete(product);
            return ApiResponse<Product>.Success(200);
        }

        public ApiResponse<ProductGetDto> GetById(int ProductId, params string[] includeList)
        {
            var product = _repo.GetById(ProductId, includeList);
            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return ApiResponse<ProductGetDto>.Success(200,dto); 
            }
            return null;
        }

        public ApiResponse<List<ProductGetDto>> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            var products = _repo.GetByPriceRange(min, max, includeList);
            if (products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(200, dtoList);
            }
            return null;
        }

        public ApiResponse<List<ProductGetDto>> GetByStockRange(short min, short max, params string[] includeList)
        {
            var products = _repo.GetByStockRange(min, max, includeList);
            if (products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(200,dtoList);
            }
            return null;
        }

        public ApiResponse<List<ProductGetDto>> GetProducts(params string[] includeList)
        {
            var products = _repo.GetAll(includeList: includeList);
            if (products.Count > 0)
            {
                var dtoList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(200, dtoList);
            }
            return null;
        }

        public ApiResponse<Product> UpdateProduct(ProductPutDto entity)
        {


            var dto = _mapper.Map<Product>(entity);

            _repo.Update(dto);

            return ApiResponse<Product>.Success(200);
        }
    }
}
