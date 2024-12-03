using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
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

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.OutcomeAppServices
{
    public class ImportOutcomesFromExcelAppService : ApplicationService, IImportOutcomesFromExcelAppService
    {
        private readonly IRepository<Outcome, Guid> _outcomeRepository;
        private readonly IRepository<TrainingProgram, Guid> _trainingProgramRepository;
        private readonly CourseClientService _courseService;   

        public ImportOutcomesFromExcelAppService(IRepository<Outcome, Guid> outcomeRepository, IRepository<TrainingProgram, Guid> trainingProgramRepository,
            CourseClientService courseService)
        {
            _outcomeRepository = outcomeRepository;
            _trainingProgramRepository = trainingProgramRepository;
            _courseService = courseService;
        }

        public async Task<ListResultDto<OutcomeDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedOutcomes = new List<Outcome>();
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
                        var code = worksheet.Cells[row, 2].Text;
                        var description = worksheet.Cells[row, 3].Text;
                        var outcomeCode = worksheet.Cells[row, 4].Text;
                        var trainingProgramName = worksheet.Cells[row, 5].Text;
                        var courseName = worksheet.Cells[row, 6].Text;
                        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(description) ||
                            string.IsNullOrWhiteSpace(trainingProgramName))
                        {
                            continue;
                        }
                        var trainingProgram = await _trainingProgramRepository.FirstOrDefaultAsync(t => t.Name == trainingProgramName);
                        if (trainingProgram == null)
                        {
                            continue;
                        }
                        var outcomesCode = !string.IsNullOrWhiteSpace(outcomeCode) ? outcomeCode : null;
                        var course = !string.IsNullOrWhiteSpace(courseName) ? await _courseService.FindCourseByName(courseName) : null;
                        
                        var outcome = new Outcome
                        {
                            Type = type,
                            Code = code,
                            Description = description,
                            OutcomeCode = outcomesCode,
                            TrainingProgramId = trainingProgram.Id,
                            CourseId = course?.Id,
                        };
                        importedOutcomes.Add(outcome);
                    }
                }
            }
            // Lưu vào database
            await _outcomeRepository.InsertManyAsync(importedOutcomes);
            return new ListResultDto<OutcomeDto>(
                ObjectMapper.Map<List<Outcome>, List<OutcomeDto>>(importedOutcomes)
            );
        }
    }
}
