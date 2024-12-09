using ExamDAOnAbp.QuestionBankService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices
{
    public interface IUpdateQuestionDifficulty
    {
        Task<ListResultDto<QuestionDto>> UpdateAsync();
    }
}
