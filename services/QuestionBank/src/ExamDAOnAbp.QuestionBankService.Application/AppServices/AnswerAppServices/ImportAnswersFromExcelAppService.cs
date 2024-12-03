using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.AnswerAppServices
{
    public class ImportAnswersFromExcelAppService : ApplicationService, IImportAnswersFromExcelAppService
    {
        private readonly IRepository<Answer, Guid> _answerRepository;
        private readonly IRepository<Question, Guid> _questionRepository;

        public ImportAnswersFromExcelAppService(IRepository<Answer, Guid> answerRepository, IRepository<Question, Guid> questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public async Task<ListResultDto<AnswerDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedAnswers = new List<Answer>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var content = worksheet.Cells[row, 1].Text;
                        var isCorrect = worksheet.Cells[row, 2].Text;
                        var questionContent = worksheet.Cells[row, 3].Text;
                        if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(isCorrect) || string.IsNullOrWhiteSpace(questionContent))
                        {
                            continue;
                        }
                        var question = await _questionRepository.FirstOrDefaultAsync(q => q.Content == questionContent);
                        if (question == null) 
                        {
                            continue;
                        }
                        var answer = new Answer
                        {
                            Content = content,
                            IsCorrect = bool.Parse(isCorrect),
                            QuestionId = question.Id,
                        };
                        importedAnswers.Add(answer);
                    }
                }
            }
            // Lưu vào database
            await _answerRepository.InsertManyAsync(importedAnswers);
            return new ListResultDto<AnswerDto>(
                ObjectMapper.Map<List<Answer>, List<AnswerDto>>(importedAnswers)
            );
        }
    }
}
