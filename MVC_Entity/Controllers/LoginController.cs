using MVC_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Entity.Controllers
{
    public class LoginController : Controller
    {
        private MVC_EntityContext db = new MVC_EntityContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user) {
            if(user.nome!=null && user.password != null) {
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 1 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                user.password = Convert.ToBase64String(password);
                foreach(var userInDB in db.Users.ToList()) {
                    if(userInDB.nome==user.nome && userInDB.password == user.password) {
                        FormsAuthentication.SetAuthCookie(user.nome, false);
                        if (Request.QueryString["ReturnUrl"] == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return RedirectToAction(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente novamente");
            user.password = "";
            return View(user);
        }
    }
}