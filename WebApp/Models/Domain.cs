﻿using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Domain
    {
        public Domain()
        {
            Classroom = new HashSet<Classroom>();
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Classroom> Classroom { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
