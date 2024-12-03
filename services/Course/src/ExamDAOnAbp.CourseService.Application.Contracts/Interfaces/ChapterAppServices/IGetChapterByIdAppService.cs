using ExamDAOnAbp.CourseService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices
{
    public interface IGetChapterByIdAppService : IApplicationService
    {
        Task<ChapterDto> GetAsync(Guid id);
    }
}
