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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBs _categoryBs;


        public CategoriesController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(ApiResponse<ProductGetDto>))]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = _categoryBs.GetById(id);
            //if(category == null)
            //    return NotFound();

            return Ok(response);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var response = _categoryBs.GetCategories();

            return Ok(response);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [HttpGet("GetByDescription")]
        public IActionResult GetByDescription([FromQuery] string desc)
        {
            var response = _categoryBs.GetByDescription(desc);

            return Ok(response);

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Product>))]
        [HttpPost]
        public IActionResult SaveNewCategory([FromBody] CategoryPostDto dto)
        {
            if (dto == null)
                return BadRequest("{error: 'Gerekli veri gonderilmedi'} ");

            var response = _categoryBs.AddCategory(dto);

            return Ok(response);
        }
    }
}
