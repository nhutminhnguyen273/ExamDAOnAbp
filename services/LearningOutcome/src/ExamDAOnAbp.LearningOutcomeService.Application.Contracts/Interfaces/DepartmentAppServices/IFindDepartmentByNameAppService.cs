using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices
{
    public interface IFindDepartmentByNameAppService : IApplicationService
    {
        Task<DepartmentDto> FindAsync(string name);
    }
}
