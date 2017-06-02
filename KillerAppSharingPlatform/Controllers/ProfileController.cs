using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerAppSharingPlatform.Classes;
using KillerAppSharingPlatform.Dal.Context;

namespace KillerAppSharingPlatform.Controllers
{
    public class ProfileController : Controller
    {
        ProfileSqlContext profileSqlContext = new ProfileSqlContext();
        // GET: Profile
        //[Secure]
        //public ActionResult Index()
        //{
        //    ViewBag.PendingFriend = profileSqlContext.LFriendPendingList(Convert.ToInt32(Session["GebruikerId"]));
        //    ViewBag.FriendList = profileSqlContext.LFriendList(Convert.ToInt32(Session["GebruikerId"]), Session["Gebruikersnaam"].ToString());
        //    return View();
        //}

        [Secure]
        public ActionResult Index(string view)
        {
            ViewBag.succesfull = view;
            ViewBag.PendingFriend = profileSqlContext.LFriendPendingList(Convert.ToInt32(Session["GebruikerId"]));
            ViewBag.FriendList = profileSqlContext.LFriendList(Convert.ToInt32(Session["GebruikerId"]), Session["Gebruikersnaam"].ToString());
            return View();
        }

        [HttpPost]
        public ActionResult addfriend(string username)
        {
            bool succesfull = false;
            succesfull = profileSqlContext.AddFriend(username, Convert.ToInt32(Session["GebruikerId"]));
            if (succesfull)
            {
                Index("");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.succesfull = "Verkeerde gebruikersnaam ingevuld.";
                Index("Verkeerde gebruikersnaam ingevuld.");
                return View("Index");
            }

            
            
        }

        [HttpPost]
        public ActionResult acceptFriend(string username)
        {
            profileSqlContext.AcceptFriend(username, Convert.ToInt32(Session["GebruikerId"]));
            Index("");
            return View("Index");
        }

        [Secure]
        public ActionResult Bericht()
        {
            var bericht = profileSqlContext.LmessageList(Convert.ToInt32(Session["GebruikerId"]));
            return View(bericht);
        }

        [HttpPost]
        public ActionResult Bericht(string username, string summary)
        {
            Message message = new Message(Convert.ToInt32(Session["GebruikerId"]), username, summary, DateTime.Now);
            profileSqlContext.SendMessage(message);
            ViewBag.succes = "Bericht verstuurd";
            Bericht();
            return View();
        }
    }
}