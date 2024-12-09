using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.StudentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.StudentControllers
{
    [Route("api/students/import")]
    [ApiController]
    public class ImportStudentsFromExcelController : ControllerBase
    {
        private readonly IImportStudentsFromExcelAppService _importStudentsFromExcelAppService;

        public ImportStudentsFromExcelController(IImportStudentsFromExcelAppService importStudentsFromExcelAppService)
        {
            _importStudentsFromExcelAppService = importStudentsFromExcelAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<StudentDto>>> ImportExcelAsync(IFormFile file)
        {
            var result = await _importStudentsFromExcelAppService.ImportExcelAsync(file);
            return Ok(result);
        }
    }
}
