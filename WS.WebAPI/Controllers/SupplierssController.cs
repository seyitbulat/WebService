using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Supplier;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierssController : BaseController
    {
        private readonly ISupplierBs _supplierBs;

        public SupplierssController(ISupplierBs supplierBs)
        {
            _supplierBs = supplierBs;
        }

        // GETBY ID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _supplierBs.GetByIdAsync(id);
            return await SendResponse(response);
        }

        // GETALLS
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var response = await _supplierBs.GetSuppliersAsync();
            return await SendResponse(response);
        }

        // GETBY CITY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycity")]
        public async Task<IActionResult> GetByCity([FromQuery] string city)
        {
            var response = await _supplierBs.GetByCityAsync(city);
            return await SendResponse(response);
        }

        // GETBY COUNTRY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycountry")]
        public async Task<IActionResult> GetByCountry([FromQuery] string country)
        {
            var response = await _supplierBs.GetByCountryAsync(country);
            return await SendResponse(response);

        }

        // GETBY COMPANY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycompany")]
        public async Task<IActionResult> GetByCompany([FromQuery] string company)
        {
            var response = await _supplierBs.GetByCompanyNameAsync(company);
            return await SendResponse(response);
        }

        // INSERT SUPPLIER
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Supplier>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Supplier>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewSupplier(SupplierPostDto dto)
        {
            var response = await _supplierBs.AddSupplierAsync(dto);
            return await SendResponse(response);
        }
    }
}
