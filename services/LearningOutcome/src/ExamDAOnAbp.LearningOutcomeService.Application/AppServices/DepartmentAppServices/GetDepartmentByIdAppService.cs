using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.DepartmentAppServices
{
    public class GetDepartmentByIdAppService : ApplicationService, IGetDepartmentByIdAppService
    {
        private readonly IRepository<Department, Guid> _departmentRepository;

        public GetDepartmentByIdAppService(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto> GetAsync(Guid id)
        {
            var department = await _departmentRepository.GetAsync(id);
            if (department == null)
            {
                throw new UserFriendlyException("Không tìm thấy khoa/viện.");
            }
            return ObjectMapper.Map<Department, DepartmentDto>(department);
        }
    }
}
