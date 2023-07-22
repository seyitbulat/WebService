using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.OrderDetail;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class OrderDetailBs : IOrderDetailBs
    {
        private readonly IOrderDetailRepository _repo;
        private readonly IMapper _mapper;

        public OrderDetailBs(IOrderDetailRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetOrderDetailByIdAsync(int id, params string[] includeList)
        {
            if (id < 0)
                throw new BadRequestException("Id degeri negatif olamaz");

            var orderDetails = await _repo.GetByIdAsync(id, includeList);
            if(orderDetails.Count > 0)
            {
                var dto = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetOrderDetailsAsync(params string[] includeList)
        {
            var orderDetails = await _repo.GetAllAsync(includeList: includeList);

            if(orderDetails != null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetByQuantityRangeAsync(short min, short max, params string[] includeList)
        {
            if (min < 0 || max < 0)
                throw new BadRequestException("min, max negatif deger alamaz");

            var orderDetails = await _repo.GetByQuantityRangeAsync(min, max, includeList);
            
            if(orderDetails !=null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }
        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetByUnitPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min < 0 || max < 0)
                throw new BadRequestException("min, max negatif deger alamaz");

            var orderDetails = await _repo.GetByUnitPriceRangeAsync(min, max, includeList);

            if (orderDetails != null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetByProductAsync(int productId, params string[] includeList)
        {
            if (productId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var orderDetails = await _repo.GetByProductAsync(productId, includeList);
            if (orderDetails != null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse< List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Siparis detayi bulunamadi");
        }
        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetByProductAsync(string productName, params string[] includeList)
        {
            if (productName == null)
                throw new BadRequestException("productName degeri girin");

            var orderDetails = await _repo.GetByProductAsync(productName, includeList);
            if(orderDetails != null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Siparis detayi bulunamadi");
        }

        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetByCategoryAsync(int categoryId, params string[] includeList)
        {
            if (categoryId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var orderDetails = await _repo.GetByCategoryAsync(categoryId, includeList);
            if (orderDetails != null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Siparis detayi bulunamadi");
        }
        public async Task<ApiResponse<List<OrderDetailGetDto>>> GetByCategoryAsync(string categoryName, params string[] includeList)
        {
            if (categoryName == null)
                throw new BadRequestException("productName degeri girin");

            var orderDetails = await _repo.GetByCategoryAsync(categoryName, includeList);
            if (orderDetails != null && orderDetails.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderDetailGetDto>>(orderDetails);
                return ApiResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Siparis detayi bulunamadi");
        }
    }
}
