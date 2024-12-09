using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.Controllers.QuestionControllers
{
    [Route("api/question/course")]
    [ApiController]
    public class GetListQuestionsByCourseIdController : ControllerBase
    {
        private readonly IGetListQuestionsByCourseIdAppService _getListQuestionsByCourseIdAppService;

        public GetListQuestionsByCourseIdController(IGetListQuestionsByCourseIdAppService getListQuestionsByCourseIdAppService)
        {
            _getListQuestionsByCourseIdAppService = getListQuestionsByCourseIdAppService;
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<ListResultDto<QuestionDto>>> GetListCoursesAsync(Guid courseId)
        {
            var result = await _getListQuestionsByCourseIdAppService.GetListByCourseAsync(courseId);
            return Ok(result);
        }
    }
}
