using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.CourseService.Controllers.ChapterControllers
{
    [Route("api/chapter/id")]
    [ApiController]
    public class GetChapterByIdController : ControllerBase
    {
        private readonly IGetChapterByIdAppService _getChapterByIdAppService;

        public GetChapterByIdController(IGetChapterByIdAppService getChapterByIdAppService)
        {
            _getChapterByIdAppService = getChapterByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChapterDto>> GetAsync(Guid id)
        {
            var result = await _getChapterByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
