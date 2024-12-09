using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.DataWarehouse.Entities
{
    public class DimExam : AggregateRoot<Guid>
    {
        public string Session { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }
        public Guid CourseId { get; set; }
        public int NumberOfStudents { get; set; }
        public ICollection<FactExamResult> ExamResults { get; set; }

        public DimExam() { }

        public DimExam(Guid id, string session, DateTime date, TimeSpan startTime, TimeSpan endTime, string room, Guid courseId, int numberOfStudents)
        {
            Id = id;
            Session = session;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Room = room;
            CourseId = courseId;
            NumberOfStudents = numberOfStudents;
        }
    }
}
