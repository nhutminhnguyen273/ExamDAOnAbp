using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.TrainingProgramAppService
{
    public class GetListTrainingProgramsAppService : ApplicationService, IGetListTrainingProgramsAppService
    {
        private readonly IRepository<TrainingProgram, Guid> _trainingProgramRepository;

        public GetListTrainingProgramsAppService(IRepository<TrainingProgram, Guid> trainingProgramRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
        }

        public async Task<ListResultDto<TrainingProgramDto>> GetListAsync()
        {
            var list = await _trainingProgramRepository.GetListAsync();
            return new ListResultDto<TrainingProgramDto>(
                ObjectMapper.Map<List<TrainingProgram>, List<TrainingProgramDto>>(list)
            );
        }
    }
}
