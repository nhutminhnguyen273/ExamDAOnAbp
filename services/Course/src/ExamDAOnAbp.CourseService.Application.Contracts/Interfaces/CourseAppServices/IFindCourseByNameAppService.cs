using ExamDAOnAbp.CourseService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.CourseAppServices
{
    public interface IFindCourseByNameAppService : IApplicationService
    {
        Task<CourseDto> FindAsync(string name);
    }
}
