using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.Controllers.QuestionControllers
{
    [Route("api/questions")]
    [ApiController]
    public class GetListQuestionsController : ControllerBase
    {
        private readonly IGetListQuestionsAppService _getListQuestionsAppService;

        public GetListQuestionsController(IGetListQuestionsAppService getListQuestionsAppService)
        {
            _getListQuestionsAppService = getListQuestionsAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<QuestionDto>>> GetListAsync()
        {
            var result = await _getListQuestionsAppService.GetListAsync();
            return Ok(result);
        }
    }
}
