using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamDAOnAbp.CourseService.Controllers.CourseControllers
{
    [Route("api/course/find-name")]
    [ApiController]
    public class FindCourseByNameController : ControllerBase
    {
        private readonly IFindCourseByNameAppService _findCourseByNameAppService;

        public FindCourseByNameController(IFindCourseByNameAppService findCourseByNameAppService)
        {
            _findCourseByNameAppService = findCourseByNameAppService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CourseDto>> FindAsync(string name)
        {
            var result = await _findCourseByNameAppService.FindAsync(name);
            return Ok(result);
        }
    }
}
