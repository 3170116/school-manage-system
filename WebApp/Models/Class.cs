using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Class
    {
        public Class()
        {
            Classroom = new HashSet<Classroom>();
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }

        public virtual ICollection<Classroom> Classroom { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
