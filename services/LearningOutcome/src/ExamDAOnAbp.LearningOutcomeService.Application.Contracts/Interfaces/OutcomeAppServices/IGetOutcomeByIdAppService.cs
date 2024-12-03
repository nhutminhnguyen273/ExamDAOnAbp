using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices
{
    public interface IGetOutcomeByIdAppService : IApplicationService
    {
        Task<OutcomeDto> GetAsync(Guid id);
    }
}
