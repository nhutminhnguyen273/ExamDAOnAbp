using ExamDAOnAbp.LearningOutcomeService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices
{
    public interface IImportDepartmentsFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<DepartmentDto>> ImportExcelAsync(IFormFile file);
    }
}
