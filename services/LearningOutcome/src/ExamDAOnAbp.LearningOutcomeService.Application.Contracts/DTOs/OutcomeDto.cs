using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.DTOs
{
    public class OutcomeDto : AuditedEntityDto<Guid>
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string OutcomeCode { get; set; }
        public Guid TrainingProgramId { get; set; }
        public Guid CourseId { get; set; }
    }
}
