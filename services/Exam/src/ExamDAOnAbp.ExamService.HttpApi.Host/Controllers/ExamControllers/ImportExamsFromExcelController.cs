using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.ExamControllers
{
    [Route("api/exams/import")]
    [ApiController]
    public class ImportExamsFromExcelController : ControllerBase
    {
        private readonly IImportExamsFromExcelAppService _importExamsFromExcelAppService;

        public ImportExamsFromExcelController(IImportExamsFromExcelAppService importExamsFromExcelAppService)
        {
            _importExamsFromExcelAppService = importExamsFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<ExamDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importExamsFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
