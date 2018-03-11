﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Entity.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoggedOut");
        }
        public ActionResult LoggedOut() {
            return RedirectToAction("Index", "Home");
        }
    }
}