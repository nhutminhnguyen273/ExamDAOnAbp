using ExamDAOnAbp.ExamService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices
{
    public interface IGetExamResultByIdAppService : IApplicationService
    {
        Task<ExamResultDto> GetAsync(Guid id);
    }
}
