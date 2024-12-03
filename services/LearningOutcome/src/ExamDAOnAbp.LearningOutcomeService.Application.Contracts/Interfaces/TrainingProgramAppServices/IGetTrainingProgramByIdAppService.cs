using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices
{
    public interface IGetTrainingProgramByIdAppService : IApplicationService
    {
        Task<TrainingProgramDto> GetAsync(Guid id);
    }
}
