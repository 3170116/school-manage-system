using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Teachinghour
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassroomId { get; set; }
        public int? CourseId { get; set; }
        public short Day { get; set; }
        public short Hour { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
