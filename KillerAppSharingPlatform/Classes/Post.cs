using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSharingPlatform.Classes
{
    public class Post
    {
        public int IdPost { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public DateTime DateTime { get; private set; } = DateTime.Now;
        public int IdTopic { get; private set; }
        public int IdCreator { get; private set; }

        public Post(int idPost, string title, string summary, DateTime dateTime, int idTopic, int idCreator)
        {
            IdPost = idPost;
            Title = title;
            Summary = summary;
            DateTime = dateTime;
            IdTopic = idTopic;
            IdCreator = idCreator;
        }

        public Post(string title, string summary, int idTopic, int idCreator)
        {
            Title = title;
            Summary = summary;
            IdTopic = idTopic;
            IdCreator = idCreator;
        }
    }
}