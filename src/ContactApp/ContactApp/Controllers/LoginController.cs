using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ContactApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DataModel.Models.UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
                if (user.Email=="sa@user" && user.Password=="P@ssw0rd")
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false,"Admin");
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Contact");
            }
            ModelState.AddModelError("","Invalid login details");
            return View(user);
        }
    }
}