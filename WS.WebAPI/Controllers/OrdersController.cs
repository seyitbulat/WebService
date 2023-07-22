using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Order;
using WS.Model.Dtos.Product;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderBs _orderBs;

        public OrdersController(IOrderBs orderBs)
        {
            _orderBs = orderBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderBs.GetOrders();
            return await  SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var response = await _orderBs.GetByIdAsync(id);
            return await SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbydate")]
        public async Task<IActionResult> GetOrderByDate([FromQuery] DateTime orderDate)
        {
            var response = await _orderBs.GetByOrderDateAsync(orderDate);
            return await SendResponse(response);
        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyemployee/{id}")]
        public async Task<IActionResult> GetByEmployee([FromQuery] int id)
        {
            var response = await _orderBs.GetByEmployeeAsync(id);
            return await SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyemployee")]
        public async Task<IActionResult> GetByEmployee([FromQuery] string employeeName)
        {
            var response = await _orderBs.GetByEmployeeAsync(employeeName);
            return await SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycustomer/{id}")]
        public async Task<IActionResult> GetByCustomer([FromQuery] string id)
        {
            var response = await _orderBs.GetByCustomerAsync(id);
            return await SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycustomer")]
        public async Task<IActionResult> GetByCustomerContact([FromQuery] string contactName)
        {
            var response = await _orderBs.GetByCustomerContactAsync(contactName);
            return await SendResponse(response);
        }

    }
}
