using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.Controllers.ChapterControllers
{
    [Route("api/chapter/import")]
    [ApiController]
    public class ImportChaptersFromExcelController : ControllerBase
    {
        private readonly IImportChaptersFromExcelAppService _importChaptersFromExcelAppService;

        public ImportChaptersFromExcelController(IImportChaptersFromExcelAppService importChaptersFromExcelAppService)
        {
            _importChaptersFromExcelAppService = importChaptersFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<ChapterDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importChaptersFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
