using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WS.Business.Interfaces;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerBs _customerBs;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerBs customerBs, IMapper mapper)
        {
            _customerBs = customerBs;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var customer = _customerBs.GetById(id);
            if(customer == null)
                return NotFound();

            var dto = _mapper.Map<CustomerGetDto>(customer);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            List<Customer> customers = _customerBs.GetCustomers();
            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbycity")]
        public IActionResult GetByCity([FromQuery] string city)
        {
            List<Customer> customers = _customerBs.GetByCity(city);
            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbycountry")]
        public IActionResult GetByCountry([FromQuery] string country)
        {
            List<Customer> customers = _customerBs.GetByCountry(country);
            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbyphone")]
        public IActionResult GetByPhone([FromQuery] string phone)
        {
            List<Customer> customers = _customerBs.GetByPhone(phone);
            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveNewCustomer(CustomerPostDto dto)
        {
            if(dto == null)
                return BadRequest();

            var customer = _mapper.Map<Customer>(dto);
            _customerBs.AddCustomer(customer);
            return CreatedAtAction(nameof(GetById), new Customer { CustomerId = customer.CustomerId} ,customer);
        }
    }
}
