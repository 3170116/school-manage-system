using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class TeacherViewModel: BaseViewModel
    {

        public Teacher Teacher { get; set; }

        public TeacherViewModel(Teacher teacher)
        {
            Teacher = teacher;

            ShowModifyTeacherMenuItems = Teacher.CanModifyTeacher();
            ShowDeleteTeacherMenuItem = Teacher.CanDeleteTeacher();
            ShowCertificateMenuItem = Teacher.CanAddCertificate();
            ShowModifyStudentMenuItems = Teacher.CanModifyStudent();
            ShowManagementMenuItem = Teacher.CanModifySchoolProgram();

            FullName = Teacher.GetFullName();
        }

        public List<School> TeachingSchools { get; set; }

        public Dictionary<int, List<Teacher>> TeachersPerSchoolDict { get; set; }
    }
}
