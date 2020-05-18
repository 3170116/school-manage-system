using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Master: Teacher
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

        public bool signUpSchool(School school)
        {
            return true;
        }

        public bool addTeacher(Teacher teacher)
        {
            return true;
        }

        public bool deleteTeacher(Teacher teacher)
        {
            return true;
        }

        public bool addPromotionToStudent(Student student)
        {
            return true;
        }

        public bool addCertificateToStudent(Certificate certificate, Student student)
        {
            return true;
        }
    }
}
