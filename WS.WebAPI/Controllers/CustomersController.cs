using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerBs _customerBs;

        public CustomersController(ICustomerBs customerBs)
        {
            _customerBs = customerBs;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var response = _customerBs.GetById(id);
            return SendRespone(response);
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {

            var response = _customerBs.GetCustomers();
            return SendRespone(response);
        }

        [HttpGet("getbycity")]
        public IActionResult GetByCity([FromQuery] string city)
        {
            var response = _customerBs.GetByCity(city);
            return SendRespone(response);
        }

        [HttpGet("getbycountry")]
        public IActionResult GetByCountry([FromQuery] string country)
        {
            var response = _customerBs.GetByCountry(country);
            return SendRespone(response);
        }

        [HttpGet("getbyphone")]
        public IActionResult GetByPhone([FromQuery] string phone)
        {
            var response = _customerBs.GetByPhone(phone);
            return SendRespone(response);
        }

        [HttpPost]
        public IActionResult SaveNewCustomer(CustomerPostDto dto)
        {

            var response = _customerBs.AddCustomer(dto);
            return CreatedAtAction(nameof(GetById), new { CustomerId = response.Data.CustomerId }, response);
        }
    }
}
