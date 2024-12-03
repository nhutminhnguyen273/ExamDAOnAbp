using AutoMapper;
using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;

namespace ExamDAOnAbp.CourseService;

public class CourseServiceApplicationAutoMapperProfile : Profile
{
    public CourseServiceApplicationAutoMapperProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<Chapter, ChapterDto>();
    }
}
