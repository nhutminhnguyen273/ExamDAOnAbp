using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class DimAnswerDto : AuditedEntityDto<Guid>
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
}
