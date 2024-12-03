using ExamDAOnAbp.LearningOutcomeService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices
{
    public interface IGetDepartmentByIdAppService : IApplicationService
    {
        Task<DepartmentDto> GetAsync(Guid id);
    }
}
