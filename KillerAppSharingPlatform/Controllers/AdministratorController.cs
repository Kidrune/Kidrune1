using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerAppSharingPlatform.Classes;

namespace KillerAppSharingPlatform.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        [SecureAdmin]
        public ActionResult Index()
        {
            return View();
        }
    }
}