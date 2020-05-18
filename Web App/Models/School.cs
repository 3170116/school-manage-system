using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class School
{
        public int id { get; set; }

        public string fullName { get; set; }

        public string area { get; set; }

        public IEnumerable<Teacher> teachers { get; set; }

        public IEnumerable<Student> students { get; set; }

        public Teacher subMaster { get; set; }

        public Teacher master { get; set; }
}
}
