using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
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

namespace ExamDAOnAbp.CourseService.AppServices.ChapterAppServices
{
    public class ImportChaptersFromExcelAppService : ApplicationService, IImportChaptersFromExcelAppService
    {
        private readonly IRepository<Chapter, Guid> _chapterRepository;
        private readonly IRepository<Course, Guid> _courseRepository;

        public ImportChaptersFromExcelAppService(IRepository<Chapter, Guid> chapterRepository, IRepository<Course, Guid> courseRepository)
        {
            _chapterRepository = chapterRepository;
            _courseRepository = courseRepository;
        }

        public async Task<ListResultDto<ChapterDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) 
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ");
            }
            var importedChapters = new List<Chapter>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var lesson = worksheet.Cells[row, 1].Text;
                        var title = worksheet.Cells[row, 2].Text;
                        var numberOfLessons = worksheet.Cells[row, 3].Text;
                        var clo = worksheet.Cells[row, 4].Text;
                        var courseName = worksheet.Cells[row, 5].Text;
                        if (string.IsNullOrWhiteSpace(lesson) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(numberOfLessons) 
                            || string.IsNullOrWhiteSpace(clo) || string.IsNullOrWhiteSpace(courseName))
                        {
                            continue;
                        }
                        var course = await _courseRepository.FirstOrDefaultAsync(c => c.Name == courseName);
                        if (course == null)
                        {
                            continue;
                        }
                        var chapter = new Chapter
                        {
                            Lesson = lesson,
                            Title = title,
                            NumberOfLessons = int.Parse(numberOfLessons),
                            CLOs = clo,
                            CourseId = course.Id,
                        };
                        importedChapters.Add(chapter);
                    }
                }
            }
            // Lưu vào database
            await _chapterRepository.InsertManyAsync(importedChapters);
            return new ListResultDto<ChapterDto>(
                ObjectMapper.Map<List<Chapter>, List<ChapterDto>>(importedChapters)
            );
        }
    }
}
