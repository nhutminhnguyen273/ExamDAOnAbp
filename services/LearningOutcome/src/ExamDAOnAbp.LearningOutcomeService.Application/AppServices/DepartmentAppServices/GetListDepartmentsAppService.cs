using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.DepartmentAppServices
{
    public class GetListDepartmentsAppService : ApplicationService, IGetListDepartmentsAppService
    {
        private readonly IRepository<Department, Guid> _departmentRepository;

        public GetListDepartmentsAppService(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ListResultDto<DepartmentDto>> GetListAsync()
        {
            var list = await _departmentRepository.GetListAsync();
            return new ListResultDto<DepartmentDto>(
                ObjectMapper.Map<List<Department>, List<DepartmentDto>>(list)
            );
        }
    }
}
