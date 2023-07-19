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

        public ApiResponse<CustomerGetDto> GetById(string id)
        {
            try
            {
                if (id != null)
                {
                    var customer = _repo.GetById(id);
                    var dto = _mapper.Map<CustomerGetDto>(customer);
                    return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
                }
                throw new NotFoundException("Musteri bilgisi bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<CustomerGetDto>.Fail(StatusCodes.Status404NotFound, ex.Message);

                return ApiResponse<CustomerGetDto>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<Customer> AddCustomer(CustomerPostDto dto)
        {
            try
            {
                if (dto == null)
                    throw new BadRequestException("Eklenecek musteri bilgilerini giriniz");

                var customer = _mapper.Map<Customer>(dto);
                var insertedCustomer = _repo.Insert(customer);
                return ApiResponse<Customer>.Success(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<Customer>.Fail(StatusCodes.Status404NotFound, ex.Message);

                return ApiResponse<Customer>.Fail(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        public ApiResponse<List<CustomerGetDto>> GetByCity(string city)
        {
            try
            {
                if (city == null)
                    throw new BadRequestException("Sehir bilgisi giriniz");
                var customers = _repo.GetByCity(city);
                if (customers != null && customers.Count > 0)
                {
                    var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                    return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }
                throw new NotFoundException("Musteri bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                if (ex is BadRequestException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<List<CustomerGetDto>> GetByCountry(string country)
        {
            try
            {
                if (country == null)
                    throw new BadRequestException("Ulke bilgisi giriniz");
                var customers = _repo.GetByCountry(country);
                if (customers != null && customers.Count > 0)
                {
                    var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                    return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }
                throw new NotFoundException("Musteri bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                if (ex is BadRequestException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<List<CustomerGetDto>> GetByPhone(string phone)
        {
            try
            {
                if (phone == null)
                    throw new BadRequestException("Telefon bilgisi giriniz");
                var customers = _repo.GetByPhone(phone);
                if (customers != null && customers.Count > 0)
                {
                    var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                    return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }
                throw new NotFoundException("Musteri bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                if (ex is BadRequestException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ApiResponse<List<CustomerGetDto>> GetCustomers()
        {
            try
            {
                var customers = _repo.GetAll();
                if (customers != null && customers.Count > 0)
                {
                    var dtoList = _mapper.Map<List<CustomerGetDto>>(customers);
                    return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, dtoList);
                }
                throw new NotFoundException("Musteri bulunamadi");
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status404NotFound, ex.Message);

                if (ex is BadRequestException)
                    return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<List<CustomerGetDto>>.Fail(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
