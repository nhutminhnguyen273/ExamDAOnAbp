using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices
{
    public interface IGetListOutcomesAppService : IApplicationService
    {
        Task<ListResultDto<OutcomeDto>> GetListAsync();
    }
}
