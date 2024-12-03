using ExamDAOnAbp.ExamService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices
{
    public interface IGetListExamResultsAppService : IApplicationService
    {
        Task<ListResultDto<ExamResultDto>> GetListAsync();
    }
}
