using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Supplier;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierssController : ControllerBase
    {
        private readonly ISupplierBs _supplierBs;
        private readonly IMapper _mapper;

        public SupplierssController(ISupplierBs supplierBs, IMapper mapper)
        {
            _supplierBs = supplierBs;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var supplier = _supplierBs.GetById(id);
            if (supplier == null)
                return NotFound();

            var dto = _mapper.Map<SupplierGetDto>(supplier);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetSuppliers()
        {
            List<Supplier> suppliers = _supplierBs.GetSuppliers();
            if (suppliers.Count > 0)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return Ok(returnList);
            }

            return BadRequest();
        }

        [HttpGet("getbycity")]
        public IActionResult GetByCity([FromQuery] string city)
        {
            List<Supplier> suppliers = _supplierBs.GetByCity(city);
            if (suppliers.Count > 0)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return Ok(returnList);
            }

            return BadRequest();
        }

        [HttpGet("getbycountry")]
        public IActionResult GetByCountry([FromQuery] string country)
        {
            List<Supplier> suppliers = _supplierBs.GetByCountry(country);
            if (suppliers.Count > 0)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return Ok(returnList);
            }

            return BadRequest();
        }

        [HttpGet("getbycompany")]
        public IActionResult GetByCompany([FromQuery] string company)
        {
            List<Supplier> suppliers = _supplierBs.GetByCompanyName(company);
            if (suppliers.Count > 0)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);
                return Ok(returnList);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveNewSupplier(SupplierPostDto dto)
        {
            if(dto == null)
                return BadRequest();

            var supplier = _mapper.Map<Supplier>(dto);
            _supplierBs.SaveNewSupplier(supplier);
            return CreatedAtAction(nameof(GetById), new Supplier { SupplierId = supplier.SupplierId}, supplier);
        }
    }
}
