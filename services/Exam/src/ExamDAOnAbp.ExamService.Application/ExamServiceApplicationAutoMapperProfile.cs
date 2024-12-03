using AutoMapper;
using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;

namespace ExamDAOnAbp.ExamService;

public class ExamServiceApplicationAutoMapperProfile : Profile
{
    public ExamServiceApplicationAutoMapperProfile()
    {
        CreateMap<Exam, ExamDto>();
        CreateMap<ExamPaper, ExamPaperDto>();
        CreateMap<ExamResult, ExamResultDto>();
        CreateMap<Student, StudentDto>();
    }
}
