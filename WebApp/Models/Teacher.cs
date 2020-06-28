using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApp.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Grade = new HashSet<Grade>();
            Teachersperschool = new HashSet<Teachersperschool>();
            Teachinghour = new HashSet<Teachinghour>();

            Role = "TEACHER";
        }

        public Teacher(Teacher teacher)
        {
            Id = teacher.Id;
            Role = teacher.Role;
            Email = teacher.Email;
            Password = teacher.Password;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            DateOfBirth = teacher.DateOfBirth;
            Speciality = teacher.Speciality;
        }

        public int Id { get; set; } = 1;
        public string Role { get; set; }

        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Speciality { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<Teachersperschool> Teachersperschool { get; set; }
        public virtual ICollection<Teachinghour> Teachinghour { get; set; }


        //προσθήκη, τροποποίηση
        public virtual bool CanModifyTeacher()
        {
            return false;
        }

        public virtual bool CanDeleteTeacher()
        {
            return false;
        }

        public virtual bool CanAddCertificate()
        {
            return false;
        }

        public virtual bool CanAddPromotion()
        {
            return false;
        }

        //προσθήκη, τροποποίηση, διαγραφή
        public virtual bool CanModifyStudent()
        {
            return false;
        }

        public virtual bool CanModifySchoolProgram()
        {
            return false;
        }


        public string GetFullName()
        {
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName))
            {
                return FirstName + " " + LastName;
            }
            else if (String.IsNullOrEmpty(LastName))
            {
                return FirstName;
            }
            else if (String.IsNullOrEmpty(FirstName))
            {
                return LastName;
            }
            else
            {
                return "";
            }
        }

        public static Teacher getObjectByRole(Teacher teacher)
        {
            switch (teacher.Role.ToUpper())
            {
                case "TEACHER":
                    return teacher;
                case "SUBMASTER":
                    return new SubMaster(teacher);
                case "MASTER":
                    return new Master(teacher);
                default:
                    return null;
            }
        }
    }
}
