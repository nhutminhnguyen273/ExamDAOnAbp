using AutoMapper;
using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;

namespace ExamDAOnAbp.LearningOutcomeService;

public class LearningOutcomeServiceApplicationAutoMapperProfile : Profile
{
    public LearningOutcomeServiceApplicationAutoMapperProfile()
    {
        CreateMap<Department, DepartmentDto>();
        CreateMap<TrainingProgram, TrainingProgramDto>();
        CreateMap<Outcome, OutcomeDto>();
    }
}
