using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.AnswerAppServices
{
    public class GetListAnswersAppService : ApplicationService, IGetListAnswerAppService
    {
        private readonly IRepository<Answer, Guid> _answerRepository;

        public GetListAnswersAppService(IRepository<Answer, Guid> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<ListResultDto<AnswerDto>> GetListAsync()
        {
            var list = await _answerRepository.GetListAsync();
            return new ListResultDto<AnswerDto>(
                ObjectMapper.Map<List<Answer>, List<AnswerDto>>(list)
            );
        }
    }
}
