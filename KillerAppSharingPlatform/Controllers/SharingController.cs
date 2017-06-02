using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerAppSharingPlatform.Classes;
using KillerAppSharingPlatform.Dal.Context;

namespace KillerAppSharingPlatform.Controllers
{
    public class SharingController : Controller
    {
        readonly SharingSqlContext sharingSqlContext = new SharingSqlContext();
        public int IdPost { get; private set; }
        // GET: Sharing
        [Secure]
        public ActionResult TopicOverview()
        {
            
            var topic = sharingSqlContext.GetListTopics();
            return View(topic);
        }

        [HttpPost]
        public ActionResult TopicOverview(string message)
        {
            var topic1 = sharingSqlContext.GetListTopics();
            Response.Redirect(Request.RawUrl);
            ViewBag.TheMessage = "Topic Created";
            return View(topic1);
        }
        
        public ActionResult PostOverview(int topicId = 0)
        {

            var post = sharingSqlContext.GetListPosts(topicId);
            return View(post);
        }

        [HttpPost]
        public ActionResult PostOverview(string message)
        {
            Response.Redirect(Request.RawUrl);
            return View();
        }

        
        public ActionResult ReactionOverview(int postId = 0)
        {
            IdPost = postId;
            ViewBag.PageNumber = postId;
            //var reaction = ;
            return View(sharingSqlContext.GetListReactions(postId));
        }

        [HttpPost]
        public ActionResult ReactionOverview(int pagenumber, string Summary, HttpPostedFileBase ImageUpload)
        {
            string path = null;
            string rootetpath = null;
            ViewBag.PageNumber = pagenumber;
            //byte[] photo = null;
            if (ImageUpload != null)
            {
                path = "../Files/" + ImageUpload.FileName;
                rootetpath = Server.MapPath("../Files/" + ImageUpload.FileName);
                ImageUpload.SaveAs(rootetpath);
            }

            
            //string path = "~/Files/" + ImageUpload.FileName;
            
            //@ViewBag.Path = ImageUpload;
            //FileStream stream = new FileStream(
            //    rootetpath, FileMode.Open, FileAccess.Read);
            //BinaryReader reader = new BinaryReader(stream);
            //photo = reader.ReadBytes((int)stream.Length);
            //reader.Close();
            //stream.Close();

            Reaction reaction = new Reaction(pagenumber, Convert.ToInt32(Session["GebruikerId"]), Summary, DateTime.Now, path);
            SharingSqlContext sharingSqlContext = new SharingSqlContext();
            sharingSqlContext.CreateReaction(reaction);
            //if (path != null)
            //{
            //    if (System.IO.File.Exists(path))
            //    {
            //        System.IO.File.Delete(path);
            //    }

            //}

            //Response.Redirect(Request.RawUrl);
            //var reaction1 = sharingSqlContext.GetListReactions(IdPost);
            return View(sharingSqlContext.GetListReactions(pagenumber));
        }





    }
}