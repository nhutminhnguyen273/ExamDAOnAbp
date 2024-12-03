using ExamDAOnAbp.LearningOutcomeService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices
{
    public interface IImportOutcomesFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<OutcomeDto>> ImportExcelAsync(IFormFile file);
    }
}
