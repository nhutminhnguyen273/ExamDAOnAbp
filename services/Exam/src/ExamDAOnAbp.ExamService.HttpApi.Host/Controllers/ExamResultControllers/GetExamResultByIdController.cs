using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.ExamService.Controllers.ExamResultControllers
{
    [Route("api/exam-result/id")]
    [ApiController]
    public class GetExamResultByIdController : ControllerBase
    {
        private readonly IGetExamResultByIdAppService _getExamResultByIdAppService;

        public GetExamResultByIdController(IGetExamResultByIdAppService getExamResultByIdAppService)
        {
            _getExamResultByIdAppService = getExamResultByIdAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ExamResultDto>> GetAsync(Guid id)
        {
            var result = await _getExamResultByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
