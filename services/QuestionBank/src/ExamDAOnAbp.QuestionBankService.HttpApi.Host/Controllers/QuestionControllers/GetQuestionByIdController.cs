using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.QuestionBankService.Controllers.QuestionControllers
{
    [Route("api/question/id")]
    [ApiController]
    public class GetQuestionByIdController : ControllerBase
    {
        private readonly IGetQuestionByIdAppService _getQuestionByIdAppService;

        public GetQuestionByIdController(IGetQuestionByIdAppService getQuestionByIdAppService)
        {
            _getQuestionByIdAppService = getQuestionByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetAsync(Guid id)
        {
            var result = await _getQuestionByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
