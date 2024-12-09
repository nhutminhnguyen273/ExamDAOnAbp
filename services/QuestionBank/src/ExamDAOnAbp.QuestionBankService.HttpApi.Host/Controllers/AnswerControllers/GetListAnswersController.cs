using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamDAOnAbp.QuestionBankService.Controllers.AnswerControllers
{
    [Route("api/answers")]
    [ApiController]
    public class GetListAnswersController : ControllerBase
    {
        private readonly IGetListAnswerAppService _getListAnswerAppService;

        public GetListAnswersController(IGetListAnswerAppService getListAnswerAppService)
        {
            _getListAnswerAppService = getListAnswerAppService;
        }

        [HttpGet]
        public async Task<ActionResult<AnswerDto>> GetListAsync()
        {
            var result = await _getListAnswerAppService.GetListAsync();
            return Ok(result);
        }
    }
}
