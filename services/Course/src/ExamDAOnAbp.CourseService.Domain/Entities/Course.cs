using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.CourseService.Entities
{
    public class Course : AggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Guid DepartmentId { get; set; }
        public ICollection<Chapter> Chapters { get; set; }

        public Course() { }

        public Course(Guid id, string code, string name, int credits, Guid departmentId)
        {
            Id = id;
            Code = code;
            Name = name;
            Credits = credits;
            DepartmentId = departmentId;
        }
    }
}
