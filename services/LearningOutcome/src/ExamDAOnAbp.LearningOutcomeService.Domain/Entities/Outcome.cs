using System;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.LearningOutcomeService.Entities
{
    public class Outcome : AggregateRoot<Guid>
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string? OutcomeCode { get; set; }
        public Guid TrainingProgramId { get; set; }
        public Guid? CourseId { get; set; }
        public TrainingProgram TrainingProgram { get; set; }

        public Outcome() { }
        
        public Outcome(Guid id, string type, string code, string description, string outcomeCode, Guid trainingProgramId, Guid courseId)
        {
            Id = id;
            Type = type;
            Code = code;
            Description = description;
            OutcomeCode = outcomeCode;
            TrainingProgramId = trainingProgramId;
            CourseId = courseId;
        }
    }
}
