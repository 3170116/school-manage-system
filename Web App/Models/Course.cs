using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Course
{
        public int id { get; set; }

        public string name { get; set; }

        public int hoursPerWeek { get; set; }

        public Domain domain { get; set; }

        public Class getClass { get; set; }
}
}
