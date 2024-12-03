using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.DTOs
{
    public class AnswerDto : AuditedEntityDto<Guid>
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
}
