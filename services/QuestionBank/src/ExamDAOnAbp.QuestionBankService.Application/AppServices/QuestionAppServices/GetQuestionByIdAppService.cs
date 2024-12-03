using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices
{
    public class GetQuestionByIdAppService : ApplicationService, IGetQuestionByIdAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;

        public GetQuestionByIdAppService(IRepository<Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDto> GetAsync(Guid id)
        {
            var question = await _questionRepository.GetAsync(id);
            return ObjectMapper.Map<Question, QuestionDto>(question);
        }
    }
}
