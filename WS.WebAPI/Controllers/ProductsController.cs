using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductBs _productBs;


        public ProductsController(IProductBs productBs)
        {
            _productBs = productBs;
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _productBs.GetByIdAsync(id, "Category", "Supplier");

            return SendRespone(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            #region MAPPING YONTEM 1
            //var products = _productBs.GetProducts("Category");

            //if (products.Count > 0)
            //{
            //    var returnList = new List<ProductGetDto>();
            //    foreach (var product in products)
            //    {
            //        var dto = new ProductGetDto();
            //        dto.ProductId = product.ProductId;
            //        dto.ProductName = product.ProductName;
            //        dto.CategoryName = product.Category.CategoryName;
            //        dto.UnitPrice = product.UnitPrice;
            //        dto.UnitsInStock = product.UnitsInStock;

            //        returnList.Add(dto);
            //    }
            //   return Ok(returnList);
            //}

            //return NotFound();
            #endregion
            #region MAPPING YONTEM 2
            //var products = _productBs.GetProducts("Category");

            //if (products.Count > 0)
            //{
            //    var returnList = products.Select(prd =>
            //    new ProductGetDto()
            //    {
            //        ProductId = prd.ProductId,
            //        ProductName = prd.ProductName,
            //        UnitPrice = prd.UnitPrice,
            //        CategoryName = prd.Category.CategoryName,
            //        UnitsInStock = prd.UnitsInStock
            //    }).ToList();
            //    return Ok(returnList);
            //}

            //return NotFound();
            #endregion
            #region MAPPING YONTEM 3
            var response = await _productBs.GetProductsAsync("Category", "Supplier");
            return SendRespone(response);

            //if (products.Count > 0)
            //{
            //    return Ok(response);
            //}
            //return NotFound();
            #endregion
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyprice")]
        public async Task<IActionResult> GetByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _productBs.GetByPriceRangeAsync(min, max, "Category", "Supplier");
            return SendRespone(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbystock")]
        public async Task<IActionResult> GetByStock([FromQuery] short min, [FromQuery] short max)
        {
            var response = await _productBs.GetByStockRangeAsync(min, max, "Category", "Supplier");

            return SendRespone(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewProduct([FromBody] ProductPostDto dto)
        {

            var response = await _productBs.AddProductAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.ProductId }, response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductPutDto dto)
        {
            var response = await _productBs.UpdateProductAsync(dto);
            return SendRespone(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var response = await _productBs.GetByIdAsync(id);

            return SendRespone(response);
        }
    }
}
