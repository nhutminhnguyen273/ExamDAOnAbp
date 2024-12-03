using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices
{
    public class GetListQuestionsAppService : ApplicationService, IGetListQuestionsAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;

        public GetListQuestionsAppService(IRepository<Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<ListResultDto<QuestionDto>> GetListAsync()
        {
            var list = await _questionRepository.GetListAsync();
            return new ListResultDto<QuestionDto>(
                ObjectMapper.Map<List<Question>, List<QuestionDto>>(list)
            );
        }
    }
}
