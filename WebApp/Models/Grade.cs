using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public float Grade1 { get; set; }
        public short Semester { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
