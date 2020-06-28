using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly SMSContext storeDB;

        public HomeController(SMSContext _storeDB)
        {
            storeDB = _storeDB;

        }

        [Route("/", Name = "Index")]
        public IActionResult Index()
        {

            if (storedUserIdInSessionExists())
                return RedirectToAction("Index", "Profile");

            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Teacher = new Teacher();
            viewModel.AccountExists = null;

            return View(viewModel);
        }

        [HttpPost]
        [Route("Home/LogIn", Name = "LogIn")]
        public IActionResult LogIn(IndexViewModel viewModel)
        {

            if (storedUserIdInSessionExists())
                return RedirectToAction("Index", "Profile");

            if (ModelState.IsValid)
            {
                //check if this user exists
                if (!storeDB.ContainsAccount(viewModel.Teacher))
                {
                    viewModel.AccountExists = "False";
                    return View("Index", viewModel);
                }

                //Σώζουμε το id του χρήστη
                storeUserToSession(viewModel.Teacher.Id);

                return RedirectToAction("Index", "Profile");
            }

            return View("Index",viewModel);
        }

        [HttpPost]
        [Route("Home/Register", Name = "Register")]
        public IActionResult Register(string schoolName, string schoolArea, IndexViewModel viewModel)
        {

            if (storedUserIdInSessionExists())
                return RedirectToAction("Index", "Profile");

            if (ModelState.IsValid)
            {
                //αν υπάρχει ήδη αυτό το σχολείο
                if (storeDB.ContainsSchool(new School { FullName = schoolName }))
                {
                    viewModel.SchoolExists = "True";
                    return View("Index", viewModel);
                }
                
                Master master = new Master(viewModel.Teacher);

                //αν υπάρχει ήδη προφίλ με αυτά τα στοιχεία
                if (storeDB.ContainsAccount(master))
                {
                    viewModel.AccountExists = "True";
                    return View("Index", viewModel);
                }

                //αποθηκεύουμε τον χρήστη στη βάση
                if (!storeDB.ContainsTeacher(master))
                {
                    //σώζεις τον διευθυντή στην βάση δεδομένων
                    master.Role = "Master";

                    //αν υπάρχουν καθηγητές στην βάση, το Id παίρνει την επόμενη τιμή
                    if (storeDB.Teacher.Count() != 0)
                        master.Id = storeDB.Teacher.Select(x => x.Id).Max();

                    storeDB.Add(master);
                }

                //Σώζουμε το id του χρήστη
                storeUserToSession(master.Id);

                //Αποθηκεύουμε στη βάση δεδομένων το σχολείο
                School newSchool = new School
                {
                    Id = storeDB.School.Select(x => x.Id).Max() + 1,
                    FullName = schoolName,
                    Area = schoolArea
                };
                storeDB.School.Add(newSchool);
                storeDB.Add(new Teachersperschool
                {
                    TeacherId = master.Id,
                    SchoolId = newSchool.Id
                });

                storeDB.SaveChanges();

                return RedirectToAction("Index", "Profile");
            }

            return View("Index", viewModel);
        }

        public ActionResult LogOut()
        {
            //διαγράφουμε τον χρήστη από το session
            deleteUserFromSession();

            return RedirectToAction("Index", "Home");
        }

    }
}
