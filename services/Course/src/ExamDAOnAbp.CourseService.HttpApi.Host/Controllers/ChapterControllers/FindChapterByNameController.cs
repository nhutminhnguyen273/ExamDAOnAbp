using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamDAOnAbp.CourseService.Controllers.ChapterControllers
{
    [Route("api/chapter/find-name")]
    [ApiController]
    public class FindChapterByNameController : ControllerBase
    {
        private readonly IFindChapterByNameAppService _findChapterByNameAppService;

        public FindChapterByNameController(IFindChapterByNameAppService findChapterByNameAppService)
        {
            _findChapterByNameAppService = findChapterByNameAppService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ChapterDto>> FindAsync(string name)
        {
            var result = await _findChapterByNameAppService.FindAsync(name);
            return Ok(result);
        }
    }
}
