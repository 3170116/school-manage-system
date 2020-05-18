using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Student
{

        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string gender { get; set; }

        public DateTime dateOfBirth { get; set; }

        public int maximumJustifiedAbsences { get; set; }

        public int maximumUnJustifiedAbsences { get; set; }

        public School school { get; set; }

        public IEnumerable<Absence> absences { get; set; }

        public IEnumerable<Grade> grades { get; set; }

        public IEnumerable<Certificate> certificates { get; set; }
    }
}
