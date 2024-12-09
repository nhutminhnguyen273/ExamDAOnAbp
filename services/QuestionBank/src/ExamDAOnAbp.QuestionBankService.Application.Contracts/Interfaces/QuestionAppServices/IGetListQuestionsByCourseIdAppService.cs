using ExamDAOnAbp.QuestionBankService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices
{
    public interface IGetListQuestionsByCourseIdAppService : IApplicationService
    {
        Task<ListResultDto<QuestionDto>> GetListByCourseAsync(Guid courseId);
    }
}
