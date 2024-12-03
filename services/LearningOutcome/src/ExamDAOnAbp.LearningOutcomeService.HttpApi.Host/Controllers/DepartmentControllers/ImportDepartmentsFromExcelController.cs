using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.DepartmentControllers
{
    [Route("api/departments/import")]
    [ApiController]
    public class ImportDepartmentsFromExcelController : ControllerBase
    {
        private readonly IImportDepartmentsFromExcelAppService _importDepartmentsFromExcelAppService;
        
        public ImportDepartmentsFromExcelController(IImportDepartmentsFromExcelAppService importDepartmentsFromExcelAppService)
        {
            _importDepartmentsFromExcelAppService = importDepartmentsFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<DepartmentDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importDepartmentsFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
