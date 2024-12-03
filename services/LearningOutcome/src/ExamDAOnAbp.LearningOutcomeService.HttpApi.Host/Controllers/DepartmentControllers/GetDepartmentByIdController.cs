using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.DepartmentControllers
{
    [Route("api/department/id")]
    [ApiController]
    public class GetDepartmentByIdController : ControllerBase
    {
        private readonly IGetDepartmentByIdAppService _getDepartmentByIdAppService;

        public GetDepartmentByIdController(IGetDepartmentByIdAppService getDepartmentByIdAppService)
        {
            _getDepartmentByIdAppService = getDepartmentByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetAsync(Guid id)
        {
            var result = await _getDepartmentByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
