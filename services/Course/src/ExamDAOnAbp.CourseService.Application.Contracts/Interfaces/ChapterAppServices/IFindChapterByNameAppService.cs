using ExamDAOnAbp.CourseService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices
{
    public interface IFindChapterByNameAppService : IApplicationService
    {
        Task<ChapterDto> FindAsync(string name);
    }
}
