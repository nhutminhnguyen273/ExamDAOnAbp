using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.ExamControllers
{
    [Route("api/exam/list")]
    [ApiController]
    public class GetListExamsController : ControllerBase
    {
        private readonly IGetListExamsAppService _getListExamsAppService;

        public GetListExamsController(IGetListExamsAppService getListExamsAppService)
        {
            _getListExamsAppService = getListExamsAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<ExamDto>>> GetListAsync()
        {
            var result = await _getListExamsAppService.GetListAsync();
            return Ok(result);
        }
    }
}
