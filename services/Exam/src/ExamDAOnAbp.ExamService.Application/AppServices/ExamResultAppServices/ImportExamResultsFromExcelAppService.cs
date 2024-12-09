using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices;
using ExamDAOnAbp.QuestionBankService.HttpClients.Questions;
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

namespace ExamDAOnAbp.ExamService.AppServices.ExamResultAppServices
{
    public class ImportExamResultsFromExcelAppService : ApplicationService, IImportExamResultsFromExcelAppService
    {
        private readonly IRepository<ExamResult, Guid> _examResultRepository;
        private readonly IRepository<ExamPaper, Guid> _examPaperRepository;
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly QuestionClientService _questionService;

        public ImportExamResultsFromExcelAppService(IRepository<ExamResult, Guid> examResultRepository,
            IRepository<ExamPaper, Guid> examPaperRepository, IRepository<Student, Guid> studentRepository, QuestionClientService questionService)
        {
            _examResultRepository = examResultRepository;
            _examPaperRepository = examPaperRepository;
            _studentRepository = studentRepository;
            _questionService = questionService;
        }

        public async Task<ListResultDto<ExamResultDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedExamResults = new List<ExamResult>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <=  rowCount; row++)
                    {
                        var studentCode = worksheet.Cells[row, 1].Text;
                        var exam = worksheet.Cells[row, 2].Text;
                        var examPaperCode = worksheet.Cells[row, 3].Text;
                        var questionContent = worksheet.Cells[row, 4].Text;
                        var isCorrect = worksheet.Cells[row, 5].Text;
                        var score = worksheet.Cells[row, 6].Text;
                        if (string.IsNullOrWhiteSpace(studentCode) || string.IsNullOrWhiteSpace(exam) || string.IsNullOrWhiteSpace(examPaperCode)
                            || string.IsNullOrWhiteSpace(questionContent) || string.IsNullOrWhiteSpace(isCorrect) || string.IsNullOrWhiteSpace(score))
                        {
                            continue;
                        }
                        var student = await _studentRepository.FirstOrDefaultAsync(s => s.Code == studentCode);
                        if (student == null)
                        {
                            continue;
                        }
                        var examPaper = await _examPaperRepository.FirstOrDefaultAsync(e => e.Code == examPaperCode);
                        if (examPaper == null)
                        {
                            continue;
                        }
                        //var question = await _questionService.FindQuestionByName(questionContent);
                        //if (question == null)
                        //{
                        //    continue;
                        //}
                        var examResult = new ExamResult
                        {
                            StudentId = student.Id,
                            ExamId = Guid.Parse(exam),
                            ExamPaperId = examPaper.Id,
                            QuestionId = Guid.Parse(questionContent),
                            IsCorrect = bool.Parse(isCorrect),
                            Score = float.Parse(score),
                        };
                        importedExamResults.Add(examResult);
                    }
                }
            }
            // Lưu vào database
            await _examResultRepository.InsertManyAsync(importedExamResults);
            return new ListResultDto<ExamResultDto>(
                ObjectMapper.Map<List<ExamResult>, List<ExamResultDto>>(importedExamResults)
            );
        }
    }
}
