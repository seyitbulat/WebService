using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeBs(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int id)
        {
            if (id < 0)
                throw new BadRequestException("Id degeri negatif olamaz");

            var employee = await _repo.GetByIdAsync(id);
            if (employee != null)
            {
                var dto = _mapper.Map<EmployeeGetDto>(employee);
                return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync()
        {
            var employees = await _repo.GetAllAsync();
            if (employees != null && employees.Count > 0)
            {
                var dtoList = _mapper.Map<List<EmployeeGetDto>>(employees);
                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetByAgeRangeAsync(int min, int max)
        {
            if (min > max && min > 0 && max > 0)
                throw new BadRequestException("min, max'tan buyuk olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("min, max negatif deger alamaz");

            var employees = await _repo.GetByAgeRangeAsync(min,max);
            if (employees != null && employees.Count > 0)
            {
                var dtoList = _mapper.Map<List<EmployeeGetDto>>(employees);
                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }


        public async Task<ApiResponse<Employee>> AddEmployeeAsync(EmployeePostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Eklenecek musteri bilgisi girmelisiniz");

            var employee = _mapper.Map<Employee>(dto);
            await _repo.InsertAsync(employee);
            return ApiResponse<Employee>.Success(StatusCodes.Status201Created);
        }
    }
}
