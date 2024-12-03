using ExamDAOnAbp.CourseService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.CourseAppServices
{
    public interface IGetListCoursesAppService : IApplicationService
    {
        Task<ListResultDto<CourseDto>> GetListAsync();
    }
}
