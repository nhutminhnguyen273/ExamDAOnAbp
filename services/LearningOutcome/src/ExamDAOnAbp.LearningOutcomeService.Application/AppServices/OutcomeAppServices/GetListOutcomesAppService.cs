using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.OutcomeAppServices
{
    public class GetListOutcomesAppService : ApplicationService, IGetListOutcomesAppService
    {
        private readonly IRepository<Outcome, Guid> _outcomeRepository;

        public GetListOutcomesAppService(IRepository<Outcome, Guid> outcomeRepository)
        {
            _outcomeRepository = outcomeRepository;
        }

        public async Task<ListResultDto<OutcomeDto>> GetListAsync()
        {
            var list = await _outcomeRepository.GetListAsync();
            return new ListResultDto<OutcomeDto>(
                ObjectMapper.Map<List<Outcome>, List<OutcomeDto>>(list)
            );
        }
    }
}
