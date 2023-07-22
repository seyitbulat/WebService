using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WS.Business.Implementations;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Shipper;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : BaseController
    {
        private readonly IShipperBs _shipperBs;

        public ShippersController(IShipperBs categoryBs)
        {
            _shipperBs = categoryBs;
        }

        // GETBY ID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ShipperGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<ShipperGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _shipperBs.GetByIdAsync(id);
            return await SendResponse(response);
        }

        // GETALLS
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ShipperGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetShippers()
        {
            var response = await _shipperBs.GetShippersAsync();
            return await SendResponse(response);
        }

        // GETBY PHONE
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ShipperGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyphone")]
        public async Task<IActionResult> GetByPhone([FromQuery] string phone)
        {
            var response = await _shipperBs.GetByPhoneAsync(phone);
            return await SendResponse(response); ;
        }

        // GETBY NAME
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ShipperGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName([FromQuery] string companyName)
        {
            var response = await _shipperBs.GetByNameAsync(companyName);
            return await SendResponse(response); ;
        }

        // INSERT SHIPPER
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Shipper>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Shipper>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewShipper([FromBody] ShipperPostDto dto)
        {
            var response = await _shipperBs.AddShipperAsync(dto);
            return await SendResponse(response);
        }
    }
}
