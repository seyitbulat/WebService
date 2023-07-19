using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Dtos.Product;
using WS.Model.Dtos.Shipper;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class ShipperBs : IShipperBs
    {
        private readonly IShipperRepository _repo;
        private readonly IMapper _mapper;

        public ShipperBs(IShipperRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ShipperGetDto>> GetByIdAsync(int id)
        {
            if (id < 0)
                throw new BadRequestException("Id degeri negatif olamaz");

            var shipper = await _repo.GetByIdAsync(id);
            if (shipper != null)
            {
                var dto = _mapper.Map<ShipperGetDto>(shipper);
                return ApiResponse<ShipperGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<ShipperGetDto>>> GetShippersAsync()
        {
            var shippers = await _repo.GetAllAsync();
            if (shippers != null && shippers.Count > 0)
            {
                var dtoList = _mapper.Map<List<ShipperGetDto>>(shippers);
                return ApiResponse<List<ShipperGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<ShipperGetDto>>> GetByNameAsync(string name)
        {
            if (name == null)
                throw new BadRequestException("name degeri bos olamaz");

            var shippers = await _repo.GetByNameAsync(name);

            if (shippers != null && shippers.Count > 0)
            {
                var dtoList = _mapper.Map<List<ShipperGetDto>>(shippers);
                return ApiResponse<List<ShipperGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }

        public async Task<ApiResponse<List<ShipperGetDto>>> GetByPhoneAsync(string phone)
        {
            if (phone == null)
                throw new BadRequestException("phone degeri bos olamaz");

            var shippers = await _repo.GetByNameAsync(phone);

            if (shippers != null && shippers.Count > 0)
            {
                var dtoList = _mapper.Map<List<ShipperGetDto>>(shippers);
                return ApiResponse<List<ShipperGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException("Icerik bulunamadi");
        }


        public async Task<ApiResponse<Shipper>> AddShipperAsync(ShipperPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Gönderilecek shipper bilgisi yollamalısınz");


            var shipper = _mapper.Map<Shipper>(dto);
            var insertedList = await _repo.InsertAsync(shipper);
            return ApiResponse<Shipper>.Success(StatusCodes.Status201Created, insertedList);
        }

        public async Task<ApiResponse<NoData>> DeleteShipperAsync(int id)
        {
            if (id == null)
                throw new BadRequestException("Id girmelisiniz");

            if (id < 0)
                throw new BadRequestException("Id negatif olamaz");

            var shipper = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(shipper);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> UpdateShipperAsync(Shipper shipper)
        {
            throw new NotImplementedException();
        }
    }

}
