using ExamDAOnAbp.ExamService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices
{
    public interface IImportExamPapersFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<ExamPaperDto>> ImportExcelAsync(IFormFile file);
    }
}
