using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Course
    {
        public Course()
        {
            Grade = new HashSet<Grade>();
            Teachinghour = new HashSet<Teachinghour>();
        }

        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? DomainId { get; set; }
        public string Name { get; set; }
        public short HoursPerWeek { get; set; }

        public virtual Class Class { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<Teachinghour> Teachinghour { get; set; }
    }
}
