using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerAppSharingPlatform.Classes
{
    public class SecureAdmin : AuthorizeAttribute
    {
        private string redirect = "~/Home/login";
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Rol"] != null)
            {
                redirect = "~/Home/NoPermission";
                return httpContext.Session["Rol"].ToString() == "Administrator";
            }
            return httpContext.Session["Rol"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
           
            filterContext.Result = new RedirectResult(redirect);
        }
    }
}