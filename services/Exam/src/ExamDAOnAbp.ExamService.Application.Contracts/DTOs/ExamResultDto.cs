using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.DTOs
{
    public class ExamResultDto : AuditedEntityDto<Guid>
    {
        public string StudentCode { get; set; }
        public Guid ExamId { get; set; }
        public Guid ExamPaperId { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public float Score { get; set; }
    }
}
