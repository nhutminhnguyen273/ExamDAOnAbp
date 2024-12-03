using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.CourseService.Controllers.CourseControllers
{
    [Route("api/course/id")]
    [ApiController]
    public class GetCourseByIdController : ControllerBase
    {
        private readonly IGetCourseByIdAppService _getCourseByIdAppService;

        public GetCourseByIdController(IGetCourseByIdAppService getCourseByIdAppService)
        {
            _getCourseByIdAppService = getCourseByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetAsync(Guid id)
        {
            var result = await _getCourseByIdAppService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
