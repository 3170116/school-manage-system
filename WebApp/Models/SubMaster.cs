using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SubMaster: Teacher
    {
        public SubMaster(): base() {
            Role = "SUBMASTER";
        }

        public SubMaster(Teacher teacher) : base(teacher)
        {
            Role = "SUBMASTER";
        }

        public bool addStudent(Student student)
        {
            return true;
        }

        public bool deleteStudent(Student student)
        {
            return true;
        }

        public bool modifySchoolProgram(IEnumerable<Teachinghour> teachingHours)
        {
            return true;
        }


        override public bool CanModifyStudent()
        {
            return true;
        }

        override public bool CanModifySchoolProgram()
        {
            return true;
        }
    }
}
