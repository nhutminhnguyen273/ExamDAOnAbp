using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.OutcomeControllers
{
    [Route("api/outcomes/import")]
    [ApiController]
    public class ImportOutcomesFromExcelController : ControllerBase
    {
        private readonly IImportOutcomesFromExcelAppService _importOutcomesFromExcelAppService;

        public ImportOutcomesFromExcelController(IImportOutcomesFromExcelAppService importOutcomesFromExcelAppService)
        {
            _importOutcomesFromExcelAppService = importOutcomesFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<OutcomeDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importOutcomesFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
