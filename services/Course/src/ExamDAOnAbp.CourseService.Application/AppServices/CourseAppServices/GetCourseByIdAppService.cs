using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.CourseService.AppServices.CourseAppServices
{
    public class GetCourseByIdAppService : ApplicationService, IGetCourseByIdAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;

        public GetCourseByIdAppService(IRepository<Course, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> GetAsync(Guid id)
        {
            var course = await _courseRepository.GetAsync(id);
            return ObjectMapper.Map<Course, CourseDto>(course);
        }
    }
}
