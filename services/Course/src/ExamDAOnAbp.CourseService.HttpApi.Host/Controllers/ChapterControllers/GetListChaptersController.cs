using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.Controllers.ChapterControllers
{
    [Route("api/chapters/list")]
    [ApiController]
    public class GetListChaptersController : ControllerBase
    {
        private readonly IGetListChaptersAppService _getListChaptersAppService;

        public GetListChaptersController(IGetListChaptersAppService getListChaptersAppService)
        {
            _getListChaptersAppService = getListChaptersAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<ChapterDto>>> GetListAsync()
        {
            var result = await _getListChaptersAppService.GetListAsync();
            return Ok(result);
        }
    }
}
