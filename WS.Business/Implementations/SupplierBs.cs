using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Product;
using WS.Model.Dtos.Shipper;
using WS.Model.Dtos.Supplier;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class SupplierBs : ISupplierBs
    {
        private readonly ISupplierRepository _repo;
        private readonly IMapper _mapper;

        public SupplierBs(ISupplierRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SupplierGetDto>> GetByIdAsync(int id, params string[] includeList)
        {
            if (id < 0)
                throw new BadRequestException("Id degeri negatif olamaz");

            var supplier = await _repo.GetByIdAsync(id, includeList);
            if (supplier != null)
            {
                var dto = _mapper.Map<SupplierGetDto>(supplier);
                return ApiResponse<SupplierGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersAsync(params string[] includeList)
        {
            var suppliers = await _repo.GetAllAsync(includeList: includeList);
            if (suppliers != null && suppliers.Count > 0)
            {
                var dtoList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetByCityAsync(string city, params string[] includeList)
        {
            if (city == null)
                throw new BadRequestException("city degeri bos olamaz");

            var suppliers = await _repo.GetByCityAsync(city);

            if (suppliers != null && suppliers.Count > 0)
            {
                var dtoList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetByCountryAsync(string country, params string[] includeList)
        {
            if (country == null)
                throw new BadRequestException("country degeri bos olamaz");

            var suppliers = await _repo.GetByCountryAsync(country);

            if (suppliers != null && suppliers.Count > 0)
            {
                var dtoList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetByCompanyNameAsync(string companyName, params string[] includeList)
        {
            if (companyName == null)
                throw new BadRequestException("companyName degeri bos olamaz");

            var suppliers = await _repo.GetByCompanyNameAsync(companyName);

            if (suppliers != null && suppliers.Count > 0)
            {
                var dtoList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<Supplier>> AddSupplierAsync(SupplierPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Gönderilecek supplier bilgisi yollamalısınz");


            var suppliers = _mapper.Map<Supplier>(dto);
            var insertedList = await _repo.InsertAsync(suppliers);
            return ApiResponse<Supplier>.Success(StatusCodes.Status201Created, insertedList);
        }
    }
}
