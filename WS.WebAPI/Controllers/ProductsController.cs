using AutoMapper;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBs _productBs;
        private readonly IMapper _mapper;

        public ProductsController(IProductBs productBs, IMapper mapper)
        {
            _productBs = productBs;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productBs.GetById(id, "Category", "Supplier");
            if (product == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<ProductGetDto>(product);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetProducts()
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
            var products = _productBs.GetProducts("Category", "Supplier");

            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return Ok(returnList);
            }
            return BadRequest();
            #endregion
        }

        [HttpGet("getbyprice")]
        public IActionResult GetByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var products = _productBs.GetByPriceRange(min, max, "Category", "Supplier");

            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbystock")]
        public IActionResult GetByStock([FromQuery] short min, [FromQuery] short max)
        {
            var products = _productBs.GetByStockRange(min, max, "Category", "Supplier");
            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
            }
               
            return NotFound();
        }

        [HttpPost]
        public IActionResult SaveNewProduct([FromBody] ProductPostDto dto)
        {
            if (dto == null)
                return BadRequest("{error: 'Gerekli veri gonderilmedi'} ");
            var product = _mapper.Map<Product>(dto);

            _productBs.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);



        }
    }
}
