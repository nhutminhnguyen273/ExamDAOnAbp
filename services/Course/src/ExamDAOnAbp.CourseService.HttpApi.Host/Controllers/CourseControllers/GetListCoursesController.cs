using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.Controllers.CourseControllers
{
    [Route("api/courses/list")]
    [ApiController]
    public class GetListCoursesController : ControllerBase
    {
        private readonly IGetListCoursesAppService _getListCoursesAppService;

        public GetListCoursesController(IGetListCoursesAppService getListCoursesAppService)
        {
            _getListCoursesAppService = getListCoursesAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<CourseDto>>> GetListAsync()
        {
            var result = await _getListCoursesAppService.GetListAsync();
            return Ok(result);
        }
    }
}
