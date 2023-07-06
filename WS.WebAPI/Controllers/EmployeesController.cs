using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBs _employeeBs;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeBs employeeBs, IMapper mapper)
        {
            _employeeBs = employeeBs;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var employee = _employeeBs.GetById(id);
            if (employee == null)
                return NotFound();

            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> employees = _employeeBs.GetEmployees();
            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpGet("getbyage")]
        public IActionResult GetByAge([FromQuery] int min, [FromQuery] int max)
        {
            List<Employee> employees = _employeeBs.GetByAgeRange(min, max);
            if(employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);
                return Ok(returnList);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveNewEmployee([FromBody] EmployeePostDto dto)
        {
            if(dto == null) 
                return BadRequest();
            var employee = _mapper.Map<Employee>(dto);
            _employeeBs.AddEmployee(employee);
            return CreatedAtAction(nameof(GetById), new Employee { EmployeeId = employee.EmployeeId}, employee);
        }
    }
}
