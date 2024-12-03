using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamDAOnAbp.QuestionBankService.Controllers.QuestionControllers
{
    [Route("api/question/find-name")]
    [ApiController]
    public class FindQuestionByNameController : ControllerBase
    {
        private readonly IFindQuestionByNameAppService _findQuestionByNameAppService;

        public FindQuestionByNameController(IFindQuestionByNameAppService findQuestionByNameAppService)
        {
            _findQuestionByNameAppService = findQuestionByNameAppService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<QuestionDto>> FindAsync(string name)
        {
            var result = await _findQuestionByNameAppService.FindAsync(name);
            return Ok(result);
        }
    }
}
