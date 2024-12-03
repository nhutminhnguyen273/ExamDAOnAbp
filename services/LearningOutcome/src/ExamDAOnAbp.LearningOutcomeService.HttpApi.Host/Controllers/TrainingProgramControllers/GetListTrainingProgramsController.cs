using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.TrainingProgramControllers
{
    [Route("api/training-programs/list")]
    [ApiController]
    public class GetListTrainingProgramsController : ControllerBase
    {
        private readonly IGetListTrainingProgramsAppService _trainingProgramRepository;

        public GetListTrainingProgramsController(IGetListTrainingProgramsAppService trainingProgramRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<TrainingProgramDto>>> GetListAsync()
        {
            var result = await _trainingProgramRepository.GetListAsync();
            return Ok(result);
        }
    }
}
