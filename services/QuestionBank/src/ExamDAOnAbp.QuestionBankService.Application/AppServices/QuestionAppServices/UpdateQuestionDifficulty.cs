using ExamDAOnAbp.DataWarehouse.HttpClients;
using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices
{
    public class UpdateQuestionDifficulty : ApplicationService, IUpdateQuestionDifficulty
    {
        private readonly IRepository<Question, Guid> _questionRepository;
        private readonly DataWarehouseClientService _dataWarehouseClientService;

        public UpdateQuestionDifficulty(IRepository<Question, Guid> questionRepository, DataWarehouseClientService dataWarehouseClientService)
        {
            _questionRepository = questionRepository;
            _dataWarehouseClientService = dataWarehouseClientService;
        }

        public async Task<ListResultDto<QuestionDto>> UpdateAsync()
        {
            var dimQuestions = await _dataWarehouseClientService.GetListQuestions();
            if (dimQuestions == null || dimQuestions.Items == null || !dimQuestions.Items.Any())
            {
                throw new UserFriendlyException("Không lấy được dữ liệu.");
            }
            var existingQuestions = await _questionRepository.GetListAsync();
            foreach(var dimQuestion in dimQuestions.Items)
            {
                var question = await _questionRepository.FirstOrDefaultAsync(q => q.Id == dimQuestion.QuestionId);
                if (question != null && question.DifficultyLevel != dimQuestion.DifficultyLevel)
                {
                    question.DifficultyLevel = dimQuestion.DifficultyLevel;
                    await _questionRepository.UpdateAsync(question);
                }
            }

            return new ListResultDto<QuestionDto>(
                ObjectMapper.Map<List<Question>, List<QuestionDto>>(existingQuestions)
            );
        }
    }
}
