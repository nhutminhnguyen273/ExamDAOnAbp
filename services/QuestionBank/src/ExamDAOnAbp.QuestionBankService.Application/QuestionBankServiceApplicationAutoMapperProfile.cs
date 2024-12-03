using AutoMapper;
using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;

namespace ExamDAOnAbp.QuestionBankService;

public class QuestionBankServiceApplicationAutoMapperProfile : Profile
{
    public QuestionBankServiceApplicationAutoMapperProfile()
    {
        CreateMap<Question, QuestionDto>();
        CreateMap<Answer, AnswerDto>();
    }
}
