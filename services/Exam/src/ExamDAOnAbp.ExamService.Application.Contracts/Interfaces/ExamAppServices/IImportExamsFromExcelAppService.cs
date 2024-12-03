using ExamDAOnAbp.ExamService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamAppServices
{
    public interface IImportExamsFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<ExamDto>> ImportExcelAsync(IFormFile file);
    }
}
