using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Supplier;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ISupplierBs
    {
        Task<ApiResponse<SupplierGetDto>> GetByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersAsync(params string[] includeList);


        Task<ApiResponse<List<SupplierGetDto>>> GetByCityAsync(string city, params string[] includeList);
        Task<ApiResponse<List<SupplierGetDto>>> GetByCountryAsync(string country, params string[] includeList);
        Task<ApiResponse<List<SupplierGetDto>>> GetByCompanyNameAsync(string companyName, params string[] includeList);


        Task<ApiResponse<Supplier>> AddSupplierAsync(SupplierPostDto dto);
    }
}
