using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamAppServices;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamAppServices
{
    public class ImportExamsFromExcelAppService : ApplicationService, IImportExamsFromExcelAppService
    {
        private readonly IRepository<Exam, Guid> _examRepository;
        private readonly CourseClientService _courseService;

        public ImportExamsFromExcelAppService(IRepository<Exam, Guid> examRepository, CourseClientService courseService)
        {
            _examRepository = examRepository;
            _courseService = courseService;
        }

        public async Task<ListResultDto<ExamDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedExams = new List<Exam>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var session = worksheet.Cells[row, 1].Text;
                        var date = worksheet.Cells[row, 2].Text;
                        var startTime = worksheet.Cells[row, 3].Text;
                        var endTime = worksheet.Cells[row, 4].Text;
                        var room = worksheet.Cells[row, 5].Text;
                        var courseName = worksheet.Cells[row, 6].Text;
                        var numberOfStudents = worksheet.Cells[row, 7].Text;
                        if (string.IsNullOrWhiteSpace(session) || string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(startTime) || string.IsNullOrWhiteSpace(endTime)
                            || string.IsNullOrWhiteSpace(room) || string.IsNullOrWhiteSpace(courseName) || string.IsNullOrWhiteSpace(numberOfStudents))
                        {
                            continue;
                        }
                        var course = await _courseService.FindCourseByName(courseName);
                        if (course == null)
                        {
                            continue;
                        }
                        var startTimes = DateTime.Parse(startTime);
                        var endTimes = DateTime.Parse(endTime);
                        var exam = new Exam
                        {
                            Session = session,
                            Date = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture),
                            StartTime = startTimes.TimeOfDay,
                            EndTime = endTimes.TimeOfDay,
                            Room = room,
                            CourseId = course.Id,
                            NumberOfStudents = int.Parse(numberOfStudents)
                        };
                        importedExams.Add(exam);
                    }
                }
            }
            // Lưu vào database
            await _examRepository.InsertManyAsync(importedExams);
            return new ListResultDto<ExamDto>(
                ObjectMapper.Map<List<Exam>, List<ExamDto>>(importedExams)
            );
        }
    }
}
