using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TeacherController : BaseController
    {

        public TeacherController(SMSContext _storeDB)
        {
            storeDB = _storeDB;

        }

        [Route("Teachers")]
        public IActionResult Index()
        {
            if (!storedUserIdInSessionExists())
                return RedirectToAction("Index", "Home");

            Teacher teacher = storeDB.GetTeacherById((int)HttpContext.Session.GetInt32("userId"));

            if (teacher == null)
                return RedirectToAction("Index", "Home");

            TeacherViewModel viewModel = new TeacherViewModel(teacher);
            viewModel.TeachingSchools =  storeDB.Teachersperschool.Where(x => x.Teacher.Id == viewModel.Teacher.Id).Select(x => x.School).ToList();

            viewModel.TeachersPerSchoolDict = new Dictionary<int, List<Teacher>>();
            foreach (School school in viewModel.TeachingSchools)
            {
                viewModel.TeachersPerSchoolDict.Add(school.Id, storeDB.Teachersperschool.Where(x => x.SchoolId == school.Id).Select(x => x.Teacher).ToList());
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {

            if (ModelState.IsValid)
            {
                //check if there is already teacher with this email
                if (storeDB.ContainsAccountWithEmail(teacher.Email))
                {
                    return RedirectToAction("Index", "Profile");
                }

                //αν υπάρχουν καθηγητές στην βάση, το Id παίρνει την επόμενη τιμή
                if (storeDB.Teacher.Any())
                    teacher.Id = storeDB.getNextTeacherId();

                storeDB.Teacher.Add(teacher);
                storeDB.SaveChanges();
            }

            return RedirectToAction("Index", "Teacher");
        }
    }
}