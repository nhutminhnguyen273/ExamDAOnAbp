using ExamDAOnAbp.CourseService.HttpClients.Chapters;
using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
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

namespace ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices
{
    public class ImportQuestionsFromExcelAppService : ApplicationService, IImportQuestionsFromExcelAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;
        private readonly ChapterClientService _chapterService;

        public ImportQuestionsFromExcelAppService(IRepository<Question, Guid> questionRepository, ChapterClientService chapterService)
        {
            _questionRepository = questionRepository;
            _chapterService = chapterService;
        }

        public async Task<ListResultDto<QuestionDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedQuestions = new List<Question>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var type = worksheet.Cells[row, 1].Text;
                        var content = worksheet.Cells[row, 2].Text;
                        var chapterName = worksheet.Cells[row, 3].Text;
                        var clo = worksheet.Cells[row, 4].Text;
                        var difficultyLevel = worksheet.Cells[row, 5].Text;
                        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(chapterName) || string.IsNullOrWhiteSpace(clo))
                        {
                            continue;
                        }
                        var chapter = await _chapterService.FindChapterByName(chapterName);
                        if (chapter == null)
                        {
                            continue;
                        }
                        var question = new Question
                        {
                            Type = type,
                            Content = content,
                            ChapterId = chapter.Id,
                            CLO = clo,
                            DifficultyLevel = difficultyLevel
                        };
                        importedQuestions.Add(question);
                    }
                }
            }
            // Lưu vào database
            await _questionRepository.InsertManyAsync(importedQuestions);
            return new ListResultDto<QuestionDto>(
                ObjectMapper.Map<List<Question>, List<QuestionDto>>(importedQuestions)
            );
        }
    }
}
