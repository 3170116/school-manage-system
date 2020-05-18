using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Classroom
{
        public int id { get; set; }

        public string name { get; set; }

        public int floor { get; set; }

        public IEnumerable<Student> students { get; set; }
}
}
