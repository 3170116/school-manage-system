using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Master: Teacher
    {
        public Master(): base()
        {
            Role = "MASTER";
        }

        public Master(Teacher teacher): base(teacher)
        {
            Role = "MASTER";
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


        override public bool CanModifyTeacher()
        {
            return true;
        }

        override public bool CanDeleteTeacher()
        {
            return true;
        }

        override public bool CanAddCertificate()
        {
            return true;
        }

        override public bool CanAddPromotion()
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
