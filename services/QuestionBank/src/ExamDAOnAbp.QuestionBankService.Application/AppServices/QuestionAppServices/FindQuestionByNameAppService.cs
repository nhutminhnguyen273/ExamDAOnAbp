using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices
{
    public class FindQuestionByNameAppService : ApplicationService, IFindQuestionByNameAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;

        public FindQuestionByNameAppService(IRepository<Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDto> FindAsync(string name)
        {
            var question = await _questionRepository.FirstOrDefaultAsync(q => q.Content == name);
            return ObjectMapper.Map<Question, QuestionDto>(question);
        }
    }
}
