using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class SubMaster: Teacher
{

        public bool addStudent(Student student)
        {
            return true;
        }

        public bool deleteStudent(Student student)
        {
            return true;
        }

        public bool modifySchoolProgram(IEnumerable<TeachingHour> teachingHours)
        {
            return true;
        }
    }
}
