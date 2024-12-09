using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.DataWarehouse.Entities
{
    public class DimStudent : AggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<FactExamResult> ExamResults { get; set; }

        public DimStudent() { }

        public DimStudent(Guid id, string code, string fullName, DateTime dateOfBirth, bool gender, string email, string phone)
        {
            Id = id;
            Code = code;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            Phone = phone;
        }
    }
}
