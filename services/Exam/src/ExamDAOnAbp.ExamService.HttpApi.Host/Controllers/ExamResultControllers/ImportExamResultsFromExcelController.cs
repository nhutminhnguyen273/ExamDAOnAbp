using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.ExamResultControllers
{
    [Route("api/exam-results/import")]
    [ApiController]
    public class ImportExamResultsFromExcelController : ControllerBase
    {
        private readonly IImportExamResultsFromExcelAppService _importExamResultsFromExcelAppService;

        public ImportExamResultsFromExcelController(IImportExamResultsFromExcelAppService importExamResultsFromExcelAppService)
        {
            _importExamResultsFromExcelAppService = importExamResultsFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<ExamResultDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importExamResultsFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
