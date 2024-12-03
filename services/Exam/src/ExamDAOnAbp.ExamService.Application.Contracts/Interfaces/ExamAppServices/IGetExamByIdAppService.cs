using ExamDAOnAbp.ExamService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamAppServices
{
    public interface IGetExamByIdAppService : IApplicationService
    {
        Task<ExamDto> GetAsync(Guid id);
    }
}
