using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.AnswerAppServices
{
    public class GetAnswerByIdAppService : ApplicationService, IGetAnswerByIdAppService
    {
        private readonly IRepository<Answer, Guid> _answerRepository;

        public GetAnswerByIdAppService(IRepository<Answer, Guid> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<AnswerDto> GetAsync(Guid id)
        {
            var answer = await _answerRepository.GetAsync(id);
            return ObjectMapper.Map<Answer, AnswerDto>(answer);
        }
    }
}
