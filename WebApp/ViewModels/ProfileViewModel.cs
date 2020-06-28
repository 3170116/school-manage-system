using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class ProfileViewModel
    {

        public Teacher Teacher;

        public ProfileViewModel(Teacher teacher)
        {
            Teacher = Teacher.getObjectByRole(teacher);

            ShowModifyTeacherMenuItems = Teacher.CanModifyTeacher();
            ShowDeleteTeacherMenuItem = Teacher.CanDeleteTeacher();
            ShowCertificateMenuItem = Teacher.CanAddCertificate();
            ShowModifyStudentMenuItems = Teacher.CanModifyStudent();
            ShowManagementMenuItem = Teacher.CanModifySchoolProgram();

            FullName = Teacher.GetFullName();
        }

        public bool ShowModifyTeacherMenuItems { get; set; }

        public bool ShowDeleteTeacherMenuItem { get; set; }

        public bool ShowCertificateMenuItem { get; set; }

        public bool ShowModifyStudentMenuItems { get; set; }

        public bool ShowManagementMenuItem { get; set; }


        public string FullName { get; set; }

        public string[][] SchoolProgram { get; set; }
    }
}
