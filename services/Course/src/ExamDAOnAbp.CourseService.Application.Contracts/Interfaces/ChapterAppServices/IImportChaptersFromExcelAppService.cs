using ExamDAOnAbp.CourseService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices
{
    public interface IImportChaptersFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<ChapterDto>> ImportExcelAsync(IFormFile file);
    }
}
