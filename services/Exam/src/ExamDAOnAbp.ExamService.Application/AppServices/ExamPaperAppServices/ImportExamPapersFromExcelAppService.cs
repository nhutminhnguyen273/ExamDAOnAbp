using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using ExamDAOnAbp.QuestionBankService.HttpClients.Questions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamPaperAppServices
{
    public class ImportExamPapersFromExcelAppService : ApplicationService, IImportExamPapersFromExcelAppService
    {
        private readonly IRepository<ExamPaper, Guid> _examPaperRepository;
        private readonly CourseClientService _courseService;
        private readonly QuestionClientService _questionService;

        public ImportExamPapersFromExcelAppService(IRepository<ExamPaper, Guid> examPaperRepository, CourseClientService courseService, QuestionClientService questionService)
        {
            _examPaperRepository = examPaperRepository;
            _courseService = courseService;
            _questionService = questionService;
        }

        public async Task<ListResultDto<ExamPaperDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedExamPapers = new List<ExamPaper>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var code = worksheet.Cells[row, 1].Text;
                        var courseName = worksheet.Cells[row, 2].Text;
                        var time = worksheet.Cells[row, 3].Text;
                        var questionContents = worksheet.Cells[row, 4].Text;
                        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(courseName) || string.IsNullOrWhiteSpace(time) || string.IsNullOrWhiteSpace(questionContents))
                        {
                            continue;
                        }
                        var course = await _courseService.FindCourseByName(courseName);
                        if (course == null)
                        {
                            continue;
                        }
                        //var question = await _questionService.FindQuestionByName(questionContents);
                        //if (question == null)
                        //{
                        //    continue;
                        //}
                        var times = DateTime.Parse(time);
                        var examPaper = new ExamPaper
                        {
                            Code = code,
                            CourseId = course.Id,
                            Time = times.TimeOfDay,
                            QuestionId = Guid.Parse(questionContents),
                        };
                        importedExamPapers.Add(examPaper);
                    }
                }
            }
            // Lưu vào database
            await _examPaperRepository.InsertManyAsync(importedExamPapers);
            return new ListResultDto<ExamPaperDto>(
                ObjectMapper.Map<List<ExamPaper>, List<ExamPaperDto>>(importedExamPapers)
            );
        }
    }
}
