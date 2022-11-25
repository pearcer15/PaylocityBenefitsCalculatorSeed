using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private EmployeesService _employeesService;
        
        public EmployeesController() { 
            _employeesService = new EmployeesService();
        }


        [SwaggerOperation(Summary = "Get employee by id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Get all employees")]
        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
        {
           IEnumerable<GetEmployeeDto> employees = await _employeesService.GetAllEmployees();
            
            var result = new ApiResponse<List<GetEmployeeDto>>
            {
                Data = employees.ToList(),
                Success = true
            };
            
            return result;
        }

        [SwaggerOperation(Summary = "Add employee")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<List<AddEmployeeDto>>>> AddEmployee(AddEmployeeDto newEmployee)
        { 
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Update employee")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> UpdateEmployee(int id, UpdateEmployeeDto updatedEmployee)
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Delete employee")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
