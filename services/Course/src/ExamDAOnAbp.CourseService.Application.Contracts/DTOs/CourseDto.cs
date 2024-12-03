using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.DTOs
{
    public class CourseDto : AuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
