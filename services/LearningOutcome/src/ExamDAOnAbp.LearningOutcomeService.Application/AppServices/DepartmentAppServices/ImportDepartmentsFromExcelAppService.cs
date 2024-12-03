using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
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

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.DepartmentAppServices
{
    public class ImportDepartmentsFromExcelAppService : ApplicationService, IImportDepartmentsFromExcelAppService
    {
        private readonly IRepository<Department, Guid> _departmentRepository;

        public ImportDepartmentsFromExcelAppService(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ListResultDto<DepartmentDto>> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0 || !file.FileName.EndsWith(".xlsx"))
            {
                throw new UserFriendlyException("Tệp tải lên không hợp lệ (.xlsx).");
            }
            try
            {
                var importedDepartments = new List<Department>();
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
                            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
                            {
                                continue;
                            }
                            var departmentCode = await _departmentRepository.FirstOrDefaultAsync(d => d.Code == code);
                            var departmentName = await _departmentRepository.FirstOrDefaultAsync(d => d.Name == name);
                            if (departmentCode != null || departmentName != null)
                            {
                                continue;
                            }
                            var department = new Department
                            {
                                Code = code,
                                Name = name,
                            };
                            importedDepartments.Add(department);
                        }
                    }
                }
                // Lưu vào database
                await _departmentRepository.InsertManyAsync(importedDepartments);
                return new ListResultDto<DepartmentDto>(
                    ObjectMapper.Map<List<Department>, List<DepartmentDto>>(importedDepartments)
                );
            } catch (Exception ex)
            {
                throw new UserFriendlyException("Lỗi khi xử lý file Excel: " + ex.Message);
            }
        }
    }
}
