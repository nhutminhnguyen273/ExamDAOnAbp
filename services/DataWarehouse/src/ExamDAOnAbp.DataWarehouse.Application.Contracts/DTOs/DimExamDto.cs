using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class DimExamDto : AuditedEntityDto<Guid>
    {
        public string Session { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }
        public Guid CourseId { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
