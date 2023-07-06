using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBs _categoryBs;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryBs categoryBs, IMapper mapper)
        {
            _categoryBs = categoryBs;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = _categoryBs.GetById(id);
            if(category == null)
                return NotFound();

            var dto = _mapper.Map<CategoryGetDto>(category);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            List<Category> categories = _categoryBs.GetCategories();
            if(categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("GetByDescription")]
        public IActionResult GetByDescription([FromQuery] string desc)
        {
            List<Category> categories = _categoryBs.GetByDescription(desc);
            if(categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveNewCategory([FromBody] CategoryPostDto dto)
        {
            if(dto == null)
                return BadRequest("{error: 'Gerekli veri gonderilmedi'} ");

            var category = _mapper.Map<Category>(dto);
            _categoryBs.AddCategory(category);

            return CreatedAtAction(nameof(GetById), new Category { CategoryId=category.CategoryId },category);
        }
    }
}
