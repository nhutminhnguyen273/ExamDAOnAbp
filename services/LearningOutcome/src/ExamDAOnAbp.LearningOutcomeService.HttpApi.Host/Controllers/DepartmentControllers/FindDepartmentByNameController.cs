using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.DepartmentControllers
{
    [Route("api/department/find-name")]
    [ApiController]
    public class FindDepartmentByNameController : ControllerBase
    {
        private readonly IFindDepartmentByNameAppService _findDepartmentByNameAppService;
        
        public FindDepartmentByNameController(IFindDepartmentByNameAppService findDepartmentByNameAppService)
        {
            _findDepartmentByNameAppService = findDepartmentByNameAppService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<DepartmentDto>> FindAsync(string name)
        {
            var result = await _findDepartmentByNameAppService.FindAsync(name);
            return Ok(result);
        }
    }
}
