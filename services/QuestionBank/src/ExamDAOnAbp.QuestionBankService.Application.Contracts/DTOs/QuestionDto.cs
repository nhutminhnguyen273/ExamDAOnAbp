using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.QuestionBankService.DTOs
{
    public class QuestionDto : AuditedEntityDto<Guid>
    {
        public string Type { get; set; }
        public string Content { get; set; }
        public Guid ChapterId { get; set; }
        public string CLO { get; set; }
        public string DifficultyLevel { get; set; }
        public bool Deleted { get; set; }
    }
}
