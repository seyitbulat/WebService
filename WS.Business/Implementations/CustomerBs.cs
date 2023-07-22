using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Metrics;
using System.Numerics;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class CustomerBs : ICustomerBs
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerBs(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CustomerGetDto>> GetByIdAsync(string id)
        {
            var customers = await _repo.GetByIdAsync(id);
            if (customers != null)
            {
                var dto = _mapper.Map<CustomerGetDto>(customers);
                return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<Customer>> AddCustomerAsync(CustomerPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Eklenecek musteri bilgilerini giriniz");
            }
            var customer = _mapper.Map<Customer>(dto);
            var insertedCustomer = await _repo.InsertAsync(customer);
            return ApiResponse<Customer>.Success(StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetByCityAsync(string city)
        {
            var customers = await _repo.GetByCityAsync(city);
            if (customers != null && customers.Count > 0)
            {
                var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Musteri bulunamadi");

        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetByCountryAsync(string country)
        {
            var customers = await _repo.GetByCountryAsync(country);
            if (customers != null && customers.Count > 0)
            {
                var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Musteri bulunamadi");

        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetByPhoneAsync(string phone)
        {
            var customers = await _repo.GetByPhoneAsync(phone);
            if (customers != null && customers.Count > 0)
            {
                var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Musteri bulunamadi");

        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync()
        {
            var customers = await _repo.GetAllAsync();
            if (customers != null && customers.Count > 0)
            {
                var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Musteri bulunamadi");
        }

    }
}
