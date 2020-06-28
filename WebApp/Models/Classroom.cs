using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Classroom
    {
        public Classroom()
        {
            Studentsperclassroom = new HashSet<Studentsperclassroom>();
            Teachinghour = new HashSet<Teachinghour>();
        }

        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public int? DomainId { get; set; }
        public int? ClassId { get; set; }
        public string Name { get; set; }
        public short Floor { get; set; }

        public virtual Class Class { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Studentsperclassroom> Studentsperclassroom { get; set; }
        public virtual ICollection<Teachinghour> Teachinghour { get; set; }
    }
}
