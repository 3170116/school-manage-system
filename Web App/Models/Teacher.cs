using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher
{
        public int id { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public string speciality { get; set; }

        public School school { get; set; }

        public IEnumerable<TeachingHour> teachingHours { get; set; }

        public bool logIn()
        {
            return true;
        }

        public bool logOut()
        {
            return true;
        }

        public bool modifyAccountInfo()
        {
            return true;
        }

        public IEnumerable<TeachingHour> getSchoolProgram()
        {
            return new List<TeachingHour>();
        }

        public bool addAbsence(Student student, Absence absence)
        {
            return true;
        }

        public bool deleteAbsence(Student student, Absence absence)
        {
            return true;
        }

        public bool justifyAbsence(Absence absence)
        {
            return true;
        }

        public bool getAllAbsences(Student student)
        {
            return true;
        }

        public bool addGrade(Student student, Grade grade)
        {
            return true;
        }

    }
}
