using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.Controllers.CourseControllers
{
    [Route("api/courses/import")]
    [ApiController]
    public class ImportCoursesFromExcelController : ControllerBase
    {
        private readonly IImportCoursesFromExcelAppService _importCoursesFromExcelAppService;

        public ImportCoursesFromExcelController(IImportCoursesFromExcelAppService importCoursesFromExcelAppService)
        {
            _importCoursesFromExcelAppService = importCoursesFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<CourseDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importCoursesFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
