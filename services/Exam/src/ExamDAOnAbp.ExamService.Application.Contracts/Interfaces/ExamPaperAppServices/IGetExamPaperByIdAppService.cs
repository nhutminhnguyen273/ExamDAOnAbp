using ExamDAOnAbp.ExamService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices
{
    public interface IGetExamPaperByIdAppService : IApplicationService
    {
        Task<ExamPaperDto> GetAsync(Guid id);
    }
}
