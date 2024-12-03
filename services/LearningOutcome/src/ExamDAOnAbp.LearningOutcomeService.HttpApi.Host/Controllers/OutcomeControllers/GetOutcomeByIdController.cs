using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.OutcomeControllers
{
    [Route("api/outcome/id")]
    [ApiController]
    public class GetOutcomeByIdController : ControllerBase
    {
        private readonly IGetOutcomeByIdAppService _getOutcomeByIdAppService;

        public GetOutcomeByIdController(IGetOutcomeByIdAppService getOutcomeByIdAppService)
        {
            _getOutcomeByIdAppService = getOutcomeByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutcomeDto>> GetAsync(Guid id)
        {
            var result = await _getOutcomeByIdAppService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
