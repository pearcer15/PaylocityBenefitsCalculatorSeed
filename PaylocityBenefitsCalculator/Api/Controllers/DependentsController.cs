using Api.Dtos.Dependent;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DependentsController : ControllerBase
    {
        private DependentsService _dependentsService;

        public DependentsController(DependentsService dependentsService)
        {
            _dependentsService = dependentsService;
        }
        
        [SwaggerOperation(Summary = "Get dependent by id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Get all dependents")]
        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Add dependent")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<List<AddDependentWithEmployeeIdDto>>>> AddDependent(AddDependentWithEmployeeIdDto newDependent)
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Update dependent")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<GetDependentDto>>> UpdateDependent(int id, UpdateDependentDto updatedDependent)
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Delete dependent")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> DeleteDependent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
