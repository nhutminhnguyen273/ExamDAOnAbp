using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.LearningOutcomeService.Entities
{
    public class Department : AggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<TrainingProgram> TrainingPrograms { get; set; }
        
        public Department() { }

        public Department(Guid id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
    }
}
