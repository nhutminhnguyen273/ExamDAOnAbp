using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.CourseService.AppServices.CourseAppServices
{
    public class FindCourseByNameAppService : ApplicationService, IFindCourseByNameAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;

        public FindCourseByNameAppService(IRepository<Course, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> FindAsync(string name)
        {
            var course = await _courseRepository.FirstOrDefaultAsync(c => c.Name == name);
            return ObjectMapper.Map<Course, CourseDto>(course);
        }
    }
}
