using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class BaseViewModel
    {
        public bool ShowModifyTeacherMenuItems { get; set; }

        public bool ShowDeleteTeacherMenuItem { get; set; }

        public bool ShowCertificateMenuItem { get; set; }

        public bool ShowModifyStudentMenuItems { get; set; }

        public bool ShowManagementMenuItem { get; set; }


        public string FullName { get; set; }
    }
}
