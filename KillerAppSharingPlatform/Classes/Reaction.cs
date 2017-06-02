using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KillerAppSharingPlatform.Classes
{
    public class Reaction
    {

        public int IdReaction { get; private set; }
        public int IdPost { get; private set; }
        public int IdCreator { get; private set; }
        public string UserName { get; private set; }
        public string Summary { get; private set; }
        public int Stars { get; private set; } = 0;
        public DateTime DateTime { get; private set; }
        //public byte[] Image { get; private set; }

        public string Image { get; private set; }

        public Reaction(int idReaction, int idPost, int idCreator, string summary, int stars, DateTime dateTime, string image, string username)
        {
            IdReaction = idReaction;
            IdPost = idPost;
            IdCreator = idCreator;
            Summary = summary;
            Stars = stars;
            DateTime = dateTime;
            Image = image;
            UserName = username;
        }

        public Reaction(int idPost, int idCreator, string summary, DateTime dateTime, string image)
        {
            
            IdPost = idPost;
            IdCreator = idCreator;
            Summary = summary;
            DateTime = dateTime;
            Image = image;

        }

        public Reaction(int idReaction, int idPost, int idCreator, string summary, int stars, DateTime dateTime, string username)
        {
            IdReaction = idReaction;
            IdPost = idPost;
            IdCreator = idCreator;
            Summary = summary;
            Stars = stars;
            DateTime = dateTime;
            UserName = username;
        }

    }
}