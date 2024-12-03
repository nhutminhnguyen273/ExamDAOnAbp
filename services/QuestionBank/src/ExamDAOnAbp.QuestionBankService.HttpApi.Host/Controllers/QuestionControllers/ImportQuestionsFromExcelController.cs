using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.Controllers.QuestionControllers
{
    [Route("api/questions/import")]
    [ApiController]
    public class ImportQuestionsFromExcelController : ControllerBase
    {
        private readonly IImportQuestionsFromExcelAppService _importQuestionsFromExcelAppService;

        public ImportQuestionsFromExcelController(IImportQuestionsFromExcelAppService importQuestionsFromExcelAppService)
        {
            _importQuestionsFromExcelAppService = importQuestionsFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<QuestionDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importQuestionsFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
