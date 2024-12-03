using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.StudentAppServices;
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

namespace ExamDAOnAbp.ExamService.AppServices.StudentAppServices
{
    public class ImportStudentsFromExcelAppService : ApplicationService, IImportStudentsFromExcelAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;

        public ImportStudentsFromExcelAppService(IRepository<Student, Guid> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ListResultDto<StudentDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ");
            }
            var importedStudents = new List<Student>();
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
                        var fullName = worksheet.Cells[row, 2].Text;
                        var dateOfBirth = worksheet.Cells[row, 3].Text;
                        var genderText = worksheet.Cells[row, 4].Text;
                        var email = worksheet.Cells[row, 5].Text;
                        var phone = worksheet.Cells[row, 6].Text;
                        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(dateOfBirth) || string.IsNullOrWhiteSpace(genderText) ||
                            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
                        {
                            continue;
                        }
                        bool? gender = null;
                        if (genderText.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                        {
                            gender = true;
                        }
                        else if (genderText.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
                        {
                            gender = false;
                        }

                        if (gender == null)
                        {
                            continue;
                        }
                        var student = new Student
                        {
                            Code = code,
                            FullName = fullName,
                            DateOfBirth = DateTime.Parse(dateOfBirth),
                            Gender = gender.Value,
                            Email = email,
                            Phone = phone,
                        };
                        importedStudents.Add(student);
                    }
                }
            }
            // Lưu vào database
            await _studentRepository.InsertManyAsync(importedStudents);
            return new ListResultDto<StudentDto>(
                ObjectMapper.Map<List<Student>, List<StudentDto>>(importedStudents)
            );
        }
    }
}
