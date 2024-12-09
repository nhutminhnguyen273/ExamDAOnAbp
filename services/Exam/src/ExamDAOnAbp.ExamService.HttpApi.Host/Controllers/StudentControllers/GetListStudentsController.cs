using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.StudentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.StudentControllers
{
    [Route("api/students")]
    [ApiController]
    public class GetListStudentsController : ControllerBase
    {
        private readonly IGetListStudentsAppService _getListStudentsAppService;

        public GetListStudentsController(IGetListStudentsAppService getListStudentsAppService)
        {
            _getListStudentsAppService = getListStudentsAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<StudentDto>>> GetListAsync()
        {
            var result = await _getListStudentsAppService.GetListAsync();
            return Ok(result);
        }
    }
}
