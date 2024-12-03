using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.OutcomeControllers
{
    [Route("api/outcomes/list")]
    [ApiController]
    public class GetListOutcomesController : ControllerBase
    {
        private readonly IGetListOutcomesAppService _getListOutcomesAppService;

        public GetListOutcomesController(IGetListOutcomesAppService getListOutcomesAppService)
        {
            _getListOutcomesAppService = getListOutcomesAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<OutcomeDto>>> GetListAsync()
        {
            var result = await _getListOutcomesAppService.GetListAsync();
            return Ok(result);
        }
    }
}
