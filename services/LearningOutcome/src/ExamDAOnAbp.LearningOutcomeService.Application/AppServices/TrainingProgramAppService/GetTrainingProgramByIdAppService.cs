using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.TrainingProgramAppService
{
    public class GetTrainingProgramByIdAppService : ApplicationService, IGetTrainingProgramByIdAppService
    {
        private readonly IRepository<TrainingProgram, Guid> _trainingProgramRepository;

        public GetTrainingProgramByIdAppService(IRepository<TrainingProgram, Guid> trainingProgramRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
        }

        public async Task<TrainingProgramDto> GetAsync(Guid id)
        {
            var trainingProgram = await _trainingProgramRepository.GetAsync(id);
            return ObjectMapper.Map<TrainingProgram, TrainingProgramDto>(trainingProgram);
        }
    }
}
