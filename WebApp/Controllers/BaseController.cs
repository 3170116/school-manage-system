using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {

        protected int getUserIdFromSession()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
                return 0;

            return (int) HttpContext.Session.GetInt32("userId");
        }

        protected void storeUserToSession(int userId)
        {
            HttpContext.Session.SetInt32("userId", userId);
        }

        protected void deleteUserFromSession()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
                HttpContext.Session.SetInt32("userId", 0);
        }

        protected bool storedUserIdInSessionExists()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
                return false;

            return HttpContext.Session.GetInt32("userId") > 0 ? true : false;
        }

    }
}