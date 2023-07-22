using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Order;
using WS.Model.Dtos.OrderDetail;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class OrderBs : IOrderBs
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderBs(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<OrderGetDto>> GetByIdAsync(int id, params string[] includeList)
        {
            if (id < 0)
                throw new BadRequestException("Id degeri negatif olamaz");

            var order = await _repo.GetByIdAsync(id, includeList);
            if (order != null)
            {
                var dto = _mapper.Map<OrderGetDto>(order);
                return ApiResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }


        public async Task<ApiResponse<List<OrderGetDto>>> GetOrders(params string[] includeList)
        {
            var orders = await _repo.GetAllAsync(includeList: includeList);

            if (orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByOrderDateAsync(DateTime orderTime, params string[] includeList)
        {
            if (orderTime == null)
                throw new BadRequestException("orderTime degeri girin");

            var orders = await _repo.GetByOrderDateAsync(orderTime, includeList: includeList);

            if (orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }


        public async Task<ApiResponse<List<OrderGetDto>>> GetByEmployeeAsync(int employeeId, params string[] includeList)
        {
            if (employeeId == null)
                throw new BadRequestException("Id degeri girin");

            if (employeeId < 0)
                throw new BadRequestException("Id negatif olamaz");

            var orders = await _repo.GetByEmployeeAsync(employeeId, includeList: includeList);

            if (orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByEmployeeAsync(string employeeName, params string[] includeList)
        {
            if (employeeName == null)
                throw new BadRequestException("employeeName degeri girin");


            var orders = await _repo.GetByEmployeeAsync(employeeName, includeList: includeList);

            if (orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByCustomerAsync(string customerId, params string[] includeList)
        {
            if(customerId == null)
                throw new BadRequestException("customerId degeri girin");

            var orders = await _repo.GetByCustomerAsync(customerId, includeList);

            if(orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }
        public async Task<ApiResponse<List<OrderGetDto>>> GetByCustomerContactAsync(string contactName, params string[] includeList)
        {
            if (contactName == null)
                throw new BadRequestException("customerId degeri girin");

            var orders = await _repo.GetByCustomerAsync(contactName, includeList);

            if (orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }
    }
}
