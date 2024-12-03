using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using ExamDAOnAbp.LearningOutcomeService.HttpClients.Departments;
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

namespace ExamDAOnAbp.CourseService.AppServices.CourseAppServices
{
    public class ImportCoursesFromExcelAppService : ApplicationService, IImportCoursesFromExcelAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly DepartmentClientService _departmentService;

        public ImportCoursesFromExcelAppService(IRepository<Course, Guid> courseRepository, DepartmentClientService departmentService)
        {
            _courseRepository = courseRepository;
            _departmentService = departmentService;
        }

        public async Task<ListResultDto<CourseDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ.");
            }
            var importedCourse = new List<Course>();
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
                        var credits = worksheet.Cells[row, 3].Text;
                        var departmentName = worksheet.Cells[row, 4].Text;
                        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(credits) || string.IsNullOrWhiteSpace(departmentName)) 
                        {
                            continue;
                        }
                        var department = await _departmentService.FindDepartmentByName(departmentName);
                        if (department == null) 
                        {
                            continue;
                        }
                        var courseCode = await _courseRepository.FirstOrDefaultAsync(c => c.Code == code);
                        var courseName = await _courseRepository.FirstOrDefaultAsync(c => c.Name == name);
                        if (courseCode != null || courseName != null)
                        {
                            continue;
                        }
                        var course = new Course
                        {
                            Code = code,
                            Name = name,
                            Credits = int.Parse(credits),
                            DepartmentId = department.Id,
                        };
                        importedCourse.Add(course);
                    }
                }
            }
            // Lưu vào database 
            await _courseRepository.InsertManyAsync(importedCourse);
            return new ListResultDto<CourseDto>(
                ObjectMapper.Map<List<Course>, List<CourseDto>>(importedCourse)
            );
        }
    }
}
