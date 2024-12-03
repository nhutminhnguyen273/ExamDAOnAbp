using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.QuestionBankService.Controllers.AnswerControllers
{
    [Route("api/answer/id")]
    [ApiController]
    public class GetAnswerByIdController : ControllerBase
    {
        private readonly IGetAnswerByIdAppService _getAnswerByIdAppService;

        public GetAnswerByIdController(IGetAnswerByIdAppService getAnswerByIdAppService)
        {
            _getAnswerByIdAppService = getAnswerByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerDto>> GetAsync(Guid id)
        {
            var result = await _getAnswerByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
