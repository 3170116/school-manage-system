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
        public IActionResult EditInfo(ProfileViewModel viewModel)
        {
            if (!storedUserIdInSessionExists())
                return RedirectToAction("Index", "Home");

            Teacher teacher = storeDB.GetTeacherById((int)HttpContext.Session.GetInt32("userId"));

            if (teacher == null)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (viewModel.Teacher == null)
                {
                    return RedirectToAction("Index", "Profile");
                }

                //επιβεβαίωση ότι το email της φόρμας δεν χρησιμοποιείται από άλλον χρήστη
                if (viewModel.Teacher.Email != null && teacher.Email != viewModel.Teacher.Email)
                {
                    if (storeDB.ContainsAccountWithEmail(viewModel.Teacher.Email))
                    {
                        ViewData["emailExists"] = true;
                        viewModel = new ProfileViewModel(teacher);

                        return View(viewModel);
                    }
                }

                //επιβεβαίωση ότι το id του καθηγητή στη φόρμα είναι το ίδιο με το id του καθηγητή από το session
                if (teacher.Id == viewModel.Teacher.Id)
                {
                    storeDB.UpdateValues(viewModel.Teacher);
                    storeDB.SaveChanges();
                } else
                {
                    return RedirectToAction("Index", "Profile");
                }
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