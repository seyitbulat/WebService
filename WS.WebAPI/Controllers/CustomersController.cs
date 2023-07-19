using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerBs _customerBs;

        public CustomersController(ICustomerBs customerBs)
        {
            _customerBs = customerBs;
        }


        // GETBY ID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _customerBs.GetByIdAsync(id);
            return await SendResponse(response);
        }

        // GETALLS
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {

            var response = await _customerBs.GetCustomersAsync();
            return await SendResponse(response);
        }

        // GETBY CITY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycity")]
        public async Task<IActionResult> GetByCity([FromQuery] string city)
        {
            var response = await _customerBs.GetByCityAsync(city);
            return await SendResponse(response);
        }
        // GETBY COUNTRY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycountry")]
        public async Task<IActionResult> GetByCountry([FromQuery] string country)
        {
            var response = await _customerBs.GetByCountryAsync(country);
            return await SendResponse(response);
        }
        // GETBY COUNTRY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyphone")]
        public async Task<IActionResult> GetByPhone([FromQuery] string phone)
        {
            var response = await _customerBs.GetByPhoneAsync(phone);
            return await SendResponse(response);
        }

        // INSERT CUSTOMER
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Customer>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Customer>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewCustomer(CustomerPostDto dto)
        {

            var response = await _customerBs.AddCustomerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { CustomerId = response.Data.CustomerId }, response);
        }
    }
}
