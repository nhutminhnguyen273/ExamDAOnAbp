using ExamDAOnAbp.CourseService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.CourseAppServices
{
    public interface IImportCoursesFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<CourseDto>> ImportExcelAsync(IFormFile file);
    }
}
