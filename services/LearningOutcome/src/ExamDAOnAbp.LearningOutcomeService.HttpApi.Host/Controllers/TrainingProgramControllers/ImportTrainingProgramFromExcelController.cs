using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.TrainingProgramControllers
{
    [Route("api/training-programs/import")]
    [ApiController]
    public class ImportTrainingProgramFromExcelController : ControllerBase
    {
        private readonly IImportTrainingProgramsFromExcelAppService _importTrainingProgramsFromExcelAppService;

        public ImportTrainingProgramFromExcelController(IImportTrainingProgramsFromExcelAppService importTrainingProgramsFromExcelAppService)
        {
            _importTrainingProgramsFromExcelAppService = importTrainingProgramsFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<TrainingProgramDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importTrainingProgramsFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
