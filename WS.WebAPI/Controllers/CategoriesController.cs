using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryBs _categoryBs;


        public CategoriesController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }

        // GETBY ID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _categoryBs.GetByIdAsync(id);
            return await SendResponse(response);
        }


        // GETALLS
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryBs.GetCategoriesAsync();

            return await SendResponse(response);
        }

        // GETBY DESCRIPTION
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("GetByDescription")]
        public async Task<IActionResult> GetByDescription([FromQuery] string desc)
        {
            var response = await _categoryBs.GetByDescriptionAsync(desc);

            return await SendResponse(response);

        }

        // INSERT CATEGORY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Category>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Category>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewCategory([FromBody] CategoryPostDto dto)
        {
            var response = await _categoryBs.AddCategoryAsync(dto);
            return await SendResponse(response);
        }

        // UPDATE CATEGORY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {
            var response = await _categoryBs.UpdateCategoryAsync(dto);
            return await SendResponse(response);
        }

        // DELETE CATEGORY
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = await _categoryBs.DeleteCategoryAsync(id);
            return await SendResponse(response);
        }
    }
}