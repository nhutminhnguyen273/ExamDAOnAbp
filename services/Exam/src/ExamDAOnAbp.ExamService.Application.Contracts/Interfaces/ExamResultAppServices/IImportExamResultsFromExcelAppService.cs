﻿using ExamDAOnAbp.ExamService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices
{
    public interface IImportExamResultsFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<ExamResultDto>> ImportExcelAsync(IFormFile file);
    }
}