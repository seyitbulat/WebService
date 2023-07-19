using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Shipper;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IShipperBs
    {
        Task<ApiResponse<ShipperGetDto>> GetByIdAsync(int id);

        Task<ApiResponse<List<ShipperGetDto>>> GetShippersAsync();

        Task<ApiResponse<List<ShipperGetDto>>> GetByNameAsync(string name);
        Task<ApiResponse<List<ShipperGetDto>>> GetByPhoneAsync(string phone);
        

        Task<ApiResponse<Shipper>> AddShipperAsync(ShipperPostDto dto);

        Task<ApiResponse<NoData>> DeleteShipperAsync(int id);
        Task<ApiResponse<NoData>> UpdateShipperAsync(Shipper shipper);
    }
}
