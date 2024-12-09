using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.ExamPaperControllers
{
    [Route("api/exam-papers/import")]
    [ApiController]
    public class ImportExamPapersFromExcelController : ControllerBase
    {
        private readonly IImportExamPapersFromExcelAppService _importExamPapersFromExcelAppService;

        public ImportExamPapersFromExcelController(IImportExamPapersFromExcelAppService importExamPapersFromExcelAppService)
        {
            _importExamPapersFromExcelAppService = importExamPapersFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<ExamPaperDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importExamPapersFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
