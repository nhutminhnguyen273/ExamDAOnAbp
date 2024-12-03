using System;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.CourseService.Entities
{
    public class Chapter : AggregateRoot<Guid>
    {
        public string Lesson { get; set; }
        public string Title { get; set; }
        public int NumberOfLessons { get; set; }
        public string CLOs { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Chapter() { }

        public Chapter(Guid id, string lesson, string title, int numberOfLessons, string clos, Guid courseId)
        {
            Id = id;
            Lesson = lesson;
            Title = title;
            NumberOfLessons = numberOfLessons;
            CLOs = clos;
            CourseId = courseId;
        }
    }
}
