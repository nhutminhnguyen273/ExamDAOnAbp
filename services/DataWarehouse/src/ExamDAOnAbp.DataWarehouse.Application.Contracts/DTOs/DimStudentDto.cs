using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class DimStudentDto : AuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
