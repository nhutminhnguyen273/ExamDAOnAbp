using ExamDAOnAbp.DataWarehouse.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.DataWarehouse.Interfaces
{
    public interface IDataWarehouseAppService : IApplicationService
    {
        Task SyncExamDataAsync();
        Task<List<StudentExamStatsDto>> GetStudentAverageScoresAsync();
        Task<List<QuestionStatsDto>> GetQuestionStatsAsync();
        Task<ListResultDto<QuestionDifficultyDto>> GetQuestionDifficultyAsync();
        //Task UpdateQuestionDifficultyAsync();
    }
}
