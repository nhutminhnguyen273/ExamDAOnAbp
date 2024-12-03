using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.LearningOutcomeService.Entities
{
    public class TrainingProgram : AggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Outcome> Outcomes { get; set; }

        public TrainingProgram() {  }

        public TrainingProgram(Guid id, string code, string name, Guid departmentId)
        {
            Id = id;
            Code = code;
            Name = name;
            DepartmentId = departmentId;
        }
    }
}
