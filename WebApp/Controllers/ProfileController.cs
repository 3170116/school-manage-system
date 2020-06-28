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
    public class ProfileController : BaseController
    {
        private readonly SMSContext storeDB;

        public ProfileController(SMSContext _storeDB)
        {
            storeDB = _storeDB;

        }

        [Route("Profile")]
        public IActionResult Index()
        {
            if (!storedUserIdInSessionExists())
                return RedirectToAction("Index", "Home");

            Teacher teacher = storeDB.GetTeacherById((int) HttpContext.Session.GetInt32("userId"));

            if (teacher == null)
                return RedirectToAction("Index", "Home");

            ProfileViewModel viewModel = new ProfileViewModel(teacher);

            return View(viewModel);
        }

        [Route("Profile/Info")]
        public IActionResult Info()
        {
            if (!storedUserIdInSessionExists())
                return RedirectToAction("Index", "Home");

            Teacher teacher = storeDB.GetTeacherById((int)HttpContext.Session.GetInt32("userId"));

            if (teacher == null)
                return RedirectToAction("Index", "Home");

            ProfileViewModel viewModel = new ProfileViewModel(teacher);

            return View(viewModel);
        }

        [HttpPost]
        [Route("Profile/EditInfo", Name = "EditInfo")]
        public IActionResult EditInfo(Teacher editTeacher)
        {
            if (!storedUserIdInSessionExists())
                return RedirectToAction("Index", "Home");

            Teacher teacher = storeDB.GetTeacherById((int)HttpContext.Session.GetInt32("userId"));

            if (teacher == null)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (editTeacher == null)
                {
                    return RedirectToAction("Index", "Profile");
                }

                //επιβεβαίωση ότι το email της φόρμας δεν χρησιμοποιείται από άλλον χρήστη
                if (editTeacher.Email != null && teacher.Email != editTeacher.Email)
                {
                    if (storeDB.ContainsAccountWithEmail(editTeacher.Email))
                    {
                        ViewData["emailExists"] = true;
                        ProfileViewModel viewModel = new ProfileViewModel(teacher);

                        return View(viewModel);
                    }
                }

                //επιβεβαίωση ότι το id του καθηγητή στη φόρμα είναι το ίδιο με το id του καθηγητή από το session
                if (teacher.Id == editTeacher.Id)
                {
                    storeDB.UpdateValues(editTeacher);
                    storeDB.SaveChanges();
                } else
                {
                    return RedirectToAction("Index", "Profile");
                }
            }

            if (String.IsNullOrEmpty(editTeacher.Email))
            {
                ViewData["emailRequired"] = true;
                ProfileViewModel viewModel = new ProfileViewModel(teacher);

                return View("Info",viewModel);
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public IActionResult DeleteAccount()
        {
            if (!storedUserIdInSessionExists())
                return RedirectToAction("Index", "Home");

            Teacher teacher = storeDB.GetTeacherById((int)HttpContext.Session.GetInt32("userId"));

            if (teacher == null)
                return RedirectToAction("Index", "Home");


            //Διαγράφουμε και την απαραίτητη εγγραφή της σχέσης TeacherPerSchool
            Teachersperschool teachersperschool = storeDB.Teachersperschool.SingleOrDefault(x => x.TeacherId == teacher.Id);

            if (teachersperschool != null)
            {
                storeDB.Teachersperschool.Remove(teachersperschool);
                storeDB.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}