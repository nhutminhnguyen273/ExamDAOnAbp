using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
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

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.TrainingProgramAppService
{
    public class ImportTrainingProgramsFromExcelAppService : ApplicationService, IImportTrainingProgramsFromExcelAppService
    {
        private readonly IRepository<TrainingProgram, Guid> _trainingProgramRepository;
        private readonly IRepository<Department, Guid> _departmentRepository;

        public ImportTrainingProgramsFromExcelAppService(IRepository<TrainingProgram, Guid> trainingProgramRepository, IRepository<Department, Guid> departmentRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<ListResultDto<TrainingProgramDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedTrainingPrograms = new List<TrainingProgram>();
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
                        var name = worksheet.Cells[row, 2].Text;
                        var departmentName = worksheet.Cells[row, 3].Text;
                        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(departmentName)) 
                        {
                            continue;
                        }
                        var trainingProgramCode = await _trainingProgramRepository.FirstOrDefaultAsync(t => t.Code == code);
                        if (trainingProgramCode != null)
                        {
                            continue;
                        }
                        var department = await _departmentRepository.FirstOrDefaultAsync(d => d.Name == departmentName);
                        if (department == null) 
                        {
                            continue;
                        }
                        var trainingProgram = new TrainingProgram
                        {
                            Code = code,
                            Name = name,
                            DepartmentId = department.Id,
                        };
                        importedTrainingPrograms.Add(trainingProgram);
                    }
                }
            }
            // Lưu vào database
            await _trainingProgramRepository.InsertManyAsync(importedTrainingPrograms);
            return new ListResultDto<TrainingProgramDto>(
                ObjectMapper.Map<List<TrainingProgram>, List<TrainingProgramDto>>(importedTrainingPrograms)
            );
        }
    }
}
