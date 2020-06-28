using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Certificate = new HashSet<Certificate>();
            Grade = new HashSet<Grade>();
            Studentsperclassroom = new HashSet<Studentsperclassroom>();
        }

        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? MaximumJustifiedAbsences { get; set; }
        public int? MaximumUnJustifiedAbsences { get; set; }

        public virtual ICollection<Certificate> Certificate { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<Studentsperclassroom> Studentsperclassroom { get; set; }
    }
}
