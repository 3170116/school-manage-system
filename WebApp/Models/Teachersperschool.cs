using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Teachersperschool
    {
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
