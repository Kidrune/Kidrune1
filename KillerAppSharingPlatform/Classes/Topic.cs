using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSharingPlatform.Classes
{
    public class Topic
    {
        public int IdTopic { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public int Id_Gebruiker { get; private set; }

        public Topic(int Id, string title, string summary, int Id_gebruiker)
        {
            IdTopic = Id;
            Title = title;
            Summary = summary;
            Id_Gebruiker = Id_gebruiker;
        }

        public Topic(string title, string summary, int idGebruiker)
        {
            
            Title = title;
            Summary = summary;
            Id_Gebruiker = idGebruiker;
        }
    }
}