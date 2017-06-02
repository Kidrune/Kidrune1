using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace KillerAppSharingPlatform.Classes
{
    public class Secure : AuthorizeAttribute
    {
        /// <summary>
        /// Checks to see if the user is authenticated and has a valid session object
        /// </summary>        
        /// <param name="httpContext"></param>
        /// <returns></returns>
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //Write you authentication logic here . you can use Request headers,cookies ,..etc 
        //    bool acces = false;
        //    if (Session["Gebruikersnaam"] != null)
        //    {
        //        return true;
        //    }

        //    return acces;
        //}

        private string redirect = "~/Home/login";
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Rol"] != null)
            {
                redirect = "~/Home/NoPermission";
                return httpContext.Session["Rol"].ToString() == "User";
            }
            return httpContext.Session["Rol"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(redirect);
        }
    }
}