using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices
{
    public interface IGetListDepartmentsAppService : IApplicationService
    {
        Task<ListResultDto<DepartmentDto>> GetListAsync();
    }
}
