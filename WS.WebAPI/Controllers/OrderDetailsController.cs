using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.OrderDetail;
using WS.Model.Dtos.Product;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : BaseController
    {
        private readonly IOrderDetailBs _orderDetailBs;

        public OrderDetailsController(IOrderDetailBs orderDetailBs)
        {
            _orderDetailBs = orderDetailBs;
        }

        // GETBY ID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _orderDetailBs.GetOrderDetailByIdAsync(id, "Product", "Category");
            return await SendResponse(response);
        }

        // GETALLS
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var response = await _orderDetailBs.GetOrderDetailsAsync("Product", "Category");
            return await SendResponse(response);
        }

        // GETBY QUANTITY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyquantity")]
        public async Task<IActionResult> GetByQuantityRange([FromQuery] short min, [FromQuery] short max)
        {
            var response = await _orderDetailBs.GetByQuantityRangeAsync(min, max, "Product", "Category");
            return await SendResponse(response);
        }

        // GETBY UNITPRICE
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyunitprice")]
        public async Task<IActionResult> GetByQuantityRange([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _orderDetailBs.GetByUnitPriceRangeAsync(min, max, "Product", "Category");
            return await SendResponse(response);
        }

        // GETBY PRODUCTID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyproduct/{id}")]
        public async Task<IActionResult> GetByProductId([FromRoute] int id)
        {
            var response = await _orderDetailBs.GetByProductAsync(id, "Product", "Category");
            return await SendResponse(response);
        }

        // GETBY PRODUCTNAME
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyproduct")]
        public async Task<IActionResult> GetByProductName([FromQuery] string productName)
        {
            var response = await _orderDetailBs.GetByProductAsync(productName, "Product", "Category");
            return await SendResponse(response);
        }

        // GETBY CATEGORYID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycategory/{id}")]
        public async Task<IActionResult> GetByCategoryId([FromRoute] int id)
        {
            var response = await _orderDetailBs.GetByCategoryAsync(id, "Product", "Category");
            return await SendResponse(response);
        }

        // GETBY PRODUCTNAME
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbycategory")]
        public async Task<IActionResult> GetByCategoryName([FromQuery] string categoryName)
        {
            var response = await _orderDetailBs.GetByProductAsync(categoryName, "Product", "Category");
            return await SendResponse(response);
        }
    }
}
