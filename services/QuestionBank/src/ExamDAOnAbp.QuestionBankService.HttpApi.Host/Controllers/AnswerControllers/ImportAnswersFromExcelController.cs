using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.Controllers.AnswerControllers
{
    [Route("api/answers/import")]
    [ApiController]
    public class ImportAnswersFromExcelController : ControllerBase
    {
        private readonly IImportAnswersFromExcelAppService _importAnswersFromExcelAppService;

        public ImportAnswersFromExcelController(IImportAnswersFromExcelAppService importAnswersFromExcelAppService)
        {
            _importAnswersFromExcelAppService = importAnswersFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<AnswerDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importAnswersFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
