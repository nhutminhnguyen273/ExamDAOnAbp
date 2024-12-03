using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Entities;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.LearningOutcomeService.AppServices.DepartmentAppServices
{
    public class FindDepartmentByNameAppService : ApplicationService, IFindDepartmentByNameAppService
    {
        private readonly IRepository<Department, Guid> _departmentRepository;

        public FindDepartmentByNameAppService(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto> FindAsync(string name)
        {
            var department = await _departmentRepository.FirstOrDefaultAsync(d => d.Name == name);
            return ObjectMapper.Map<Department, DepartmentDto>(department);
        }
    }
}
