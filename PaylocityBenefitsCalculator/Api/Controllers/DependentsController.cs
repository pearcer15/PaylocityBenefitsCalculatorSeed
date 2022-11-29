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
            GetDependentDto dependent = await _dependentsService.GetDependentById(id);

            var result = new ApiResponse<GetDependentDto>
            {
                Data = dependent,
                Success = true
            };

            return result;
        }

        [SwaggerOperation(Summary = "Get all dependents")]
        [HttpGet("")]
        public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
        {
            IEnumerable<GetDependentDto> dependents = await _dependentsService.GetAllDependents();

            var result = new ApiResponse<List<GetDependentDto>>
            {
                Data = dependents.ToList(),
                Success = true
            };
            
            return result;
        }

        [SwaggerOperation(Summary = "Add dependent")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> AddDependent(AddDependentWithEmployeeIdDto newDependent)
        {
            IEnumerable<GetDependentDto> dependents = await _dependentsService.AddDependent(newDependent);

            var result = new ApiResponse<List<GetDependentDto>>
            {
                Data = dependents.ToList(),
                Success = true
            };

            return result;
        }

        [SwaggerOperation(Summary = "Update dependent")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<GetDependentDto>>> UpdateDependent(int id, UpdateDependentDto updatedDependent)
        {
            GetDependentDto dependent = await _dependentsService.UpdateDependent(id, updatedDependent);

            var result = new ApiResponse<GetDependentDto>
            {
                Data = dependent,
                Success = true
            };

            return result;
        }

        [SwaggerOperation(Summary = "Delete dependent")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> DeleteDependent(int id)
        {
            IEnumerable<GetDependentDto> dependents = await _dependentsService.DeleteDependent(id);

            var result = new ApiResponse<List<GetDependentDto>>
            {
                Data = dependents.ToList(),
                Success = true
            };

            return result;
        }
    }
}
