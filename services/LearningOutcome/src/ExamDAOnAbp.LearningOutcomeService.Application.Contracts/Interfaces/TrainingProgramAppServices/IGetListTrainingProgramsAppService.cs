using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices
{
    public interface IGetListTrainingProgramsAppService : IApplicationService
    {
        Task<ListResultDto<TrainingProgramDto>> GetListAsync();
    }
}
