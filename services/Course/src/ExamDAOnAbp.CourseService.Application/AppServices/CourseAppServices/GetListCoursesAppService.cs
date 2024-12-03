using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.CourseService.AppServices.CourseAppServices
{
    public class GetListCoursesAppService : ApplicationService, IGetListCoursesAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;

        public GetListCoursesAppService(IRepository<Course, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ListResultDto<CourseDto>> GetListAsync()
        {
            var list = await _courseRepository.GetListAsync();
            return new ListResultDto<CourseDto>(
                ObjectMapper.Map<List<Course>, List<CourseDto>>(list)
            );
        }
    }
}
