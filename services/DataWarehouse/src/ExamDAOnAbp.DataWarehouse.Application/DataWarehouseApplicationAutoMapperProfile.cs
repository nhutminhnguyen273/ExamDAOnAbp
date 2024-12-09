using AutoMapper;
using ExamDAOnAbp.DataWarehouse.DTOs;
using ExamDAOnAbp.DataWarehouse.Entities;
using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.QuestionBankService.DTOs;

namespace ExamDAOnAbp.DataWarehouse;

public class DataWarehouseApplicationAutoMapperProfile : Profile
{
    public DataWarehouseApplicationAutoMapperProfile()
    {
        CreateMap<ExamResultDto, FactExamResult>();
        CreateMap<ExamDto, DimExam>();
        CreateMap<AnswerDto, DimAnswer>();
        CreateMap<QuestionDto, DimQuestion>();
        CreateMap<StudentDto, DimStudent>();
    }
}
