using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Shipper;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperBs _shipperBs;
        private readonly IMapper _mapper;

        public ShippersController(IShipperBs categoryBs, IMapper mapper)
        {
            _shipperBs = categoryBs;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var shipper = _shipperBs.GetById(id);
            if(shipper == null)
                return NotFound();

            var dto = _mapper.Map<CategoryGetDto>(shipper);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetShippers()
        {
            List<Shipper> shippers = _shipperBs.GetShippers();
            if(shippers.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(shippers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbyphone")]
        public IActionResult GetByPhone([FromQuery] string phone)
        {
            List<Shipper> shippers = _shipperBs.GetByPhone(phone);
            if (shippers.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(shippers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName([FromQuery] string companyName)
        {
            List<Shipper> shippers = _shipperBs.GetByName(companyName);
            if (shippers.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(shippers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveNewShipper([FromBody] ShipperPostDto dto)
        {
            if(dto == null)
                return BadRequest("{error: 'Gerekli veri gonderilmedi'} ");

            var shipper = _mapper.Map<Shipper>(dto);
            _shipperBs.AddShipper(shipper);

            return CreatedAtAction(nameof(GetById), new Category { CategoryId=shipper.ShipperId },shipper);
        }
    }
}
