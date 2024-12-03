using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.ExamService.Controllers.ExamControllers
{
    [Route("api/exam/id")]
    [ApiController]
    public class GetExamByIdController : ControllerBase
    {
        private readonly IGetExamByIdAppService _getExamByIdAppService;

        public GetExamByIdController(IGetExamByIdAppService getExamByIdAppService)
        {
            _getExamByIdAppService = getExamByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamDto>> GetAsync(Guid id)
        {
            var result = await _getExamByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
