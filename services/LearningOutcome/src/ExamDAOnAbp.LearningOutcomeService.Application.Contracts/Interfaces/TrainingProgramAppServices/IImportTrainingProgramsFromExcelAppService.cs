using ExamDAOnAbp.LearningOutcomeService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices
{
    public interface IImportTrainingProgramsFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<TrainingProgramDto>> ImportExcelAsync(IFormFile file);
    }
}
