using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.AppServices.ExamPaperAppServices
{
    public class CreateExamPaper : ApplicationService, ICreateExamPaper
    {
    }
}
