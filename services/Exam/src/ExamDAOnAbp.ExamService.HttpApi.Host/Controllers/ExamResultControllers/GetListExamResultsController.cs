using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.ExamResultControllers
{
    [Route("api/exam-results")]
    [ApiController]
    public class GetListExamResultsController : ControllerBase
    {
        private readonly IGetListExamResultsAppService _getListExamResultsAppService;

        public GetListExamResultsController(IGetListExamResultsAppService getListExamResultsAppService)
        {
            _getListExamResultsAppService = getListExamResultsAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<ExamResultDto>>> GetListAsync()
        {
            var result = await _getListExamResultsAppService.GetListAsync();
            return Ok(result);
        }
    }
}
