using ExamDAOnAbp.CourseService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.CourseAppServices
{
    public interface IGetCourseByIdAppService : IApplicationService
    {
        Task<CourseDto> GetAsync(Guid id);
    }
}
