﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {

        public Teacher Teacher { get; set; }

        public ProfileViewModel() { }

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

        public string[][] SchoolProgram { get; set; }
    }
}
