using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class TeachingHour
{
        public int id { get; set; }

        public Teacher teacher { get; set; }

        public Course course { get; set; }

        public Classroom classroom { get; set; }

        public int day { get; set; }

        public int hour { get; set; }
}
}
