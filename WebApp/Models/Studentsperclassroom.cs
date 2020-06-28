using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Studentsperclassroom
    {
        public int StudentId { get; set; }
        public int ClassroomId { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual Student Student { get; set; }
    }
}
