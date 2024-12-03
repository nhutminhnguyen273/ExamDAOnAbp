using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.TrainingProgramControllers
{
    [Route("api/training-program/id")]
    [ApiController]
    public class GetTrainingProgramByIdController : ControllerBase
    {
        private readonly IGetTrainingProgramByIdAppService _getTrainingProgramByIdAppService;

        public GetTrainingProgramByIdController(IGetTrainingProgramByIdAppService getTrainingProgramByIdAppService)
        {
            _getTrainingProgramByIdAppService = getTrainingProgramByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingProgramDto>> GetAsync(Guid id)
        {
            return await _getTrainingProgramByIdAppService.GetAsync(id);
        }
    }
}
