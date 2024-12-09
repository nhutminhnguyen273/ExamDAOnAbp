using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.ExamService.Controllers.ExamPaperControllers
{
    [Route("api/exam-paper/id")]
    [ApiController]
    public class GetExamPaperByIdController : ControllerBase
    {
        private readonly IGetExamPaperByIdAppService _getExamPaperByIdAppService;

        public GetExamPaperByIdController(IGetExamPaperByIdAppService getExamPaperByIdAppService)
        {
            _getExamPaperByIdAppService = getExamPaperByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamPaperDto>> GetAsync(Guid id)
        {
            var result = await _getExamPaperByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
