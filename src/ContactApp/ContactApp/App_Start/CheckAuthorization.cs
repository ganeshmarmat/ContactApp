using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactApp.App_Start
{
    public class CheckAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["UserID"] == null || !HttpContext.Current.Request.IsAuthenticated)
            {

                filterContext.Result = new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl + "?ReturnUrl=" +
                     filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));

            }
        }
    }
}