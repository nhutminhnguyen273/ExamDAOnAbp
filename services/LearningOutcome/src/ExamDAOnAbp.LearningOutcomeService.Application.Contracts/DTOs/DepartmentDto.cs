using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.DTOs
{
    public class DepartmentDto : AuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
