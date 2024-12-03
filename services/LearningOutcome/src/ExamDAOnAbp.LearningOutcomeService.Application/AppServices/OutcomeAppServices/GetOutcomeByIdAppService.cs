using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.OutcomeAppServices
{
    public class GetOutcomeByIdAppService : ApplicationService, IGetOutcomeByIdAppService
    {
        private readonly IRepository<Outcome, Guid> _outcomeRepository;

        public GetOutcomeByIdAppService(IRepository<Outcome, Guid> outcomeRepository)
        {
            _outcomeRepository = outcomeRepository;
        }

        public async Task<OutcomeDto> GetAsync(Guid id)
        {
            var outcome = await _outcomeRepository.GetAsync(id);
            return ObjectMapper.Map<Outcome, OutcomeDto>(outcome);
        }
    }
}
