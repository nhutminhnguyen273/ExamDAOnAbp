using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class DimQuestionDto : AuditedEntityDto<Guid>
    {
        public string Type { get; set; }
        public string Content { get; set; }
        public Guid ChapterId { get; set; }
        public string CLO { get; set; }
        public string? DifficultyLevel { get; set; }
    }
}
