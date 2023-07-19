using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Category;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeBs _employeeBs;

        public EmployeesController(IEmployeeBs employeeBs)
        {
            _employeeBs = employeeBs;
        }

        // GETBY ID
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _employeeBs.GetByIdAsync(id);
            return await SendResponse(response);
        }

        // GETALLS
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var response = await _employeeBs.GetEmployeesAsync();
            return await SendResponse(response);
        }

        // GETBY AGE
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [HttpGet("getbyage")]
        public async Task<IActionResult> GetByAge([FromQuery] int min, [FromQuery] int max)
        {
            var response = await _employeeBs.GetByAgeRangeAsync(min,max);
            return await SendResponse(response);
        }

        // INSERT EMPLOYEE
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Employee>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Employee>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewEmployee([FromBody] EmployeePostDto dto)
        {
            var response = await _employeeBs.AddEmployeeAsync(dto);
            return await SendResponse(response);
        }
    }
}
