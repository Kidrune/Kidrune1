using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSharingPlatform.Classes
{
    public class Message
    {
        public int IdMessage { get; private set; }
        public int IdSender { get; private set; }
        public int IdReceiver { get; private set; }
        public string Username { get; private set; }
        public string Summary { get; private set; }
        public DateTime DateTime { get; private set; }

        public Message(int idMessage, int idSender, int idReceiver, string username, string summary, DateTime dateTime)
        {
            IdMessage = idMessage;
            IdSender = idSender;
            IdReceiver = idReceiver;
            Username = username;
            Summary = summary;
            DateTime = dateTime;
        }

        public Message(int idSender, string username, string summary, DateTime dateTime)
        {
            IdSender = idSender;
            Username = username;
            Summary = summary;
            DateTime = dateTime;
        }

        public Message(int Idmessage, int idSender, string username, string summary, DateTime dateTime)
        {
            IdMessage = Idmessage;
            IdSender = idSender;
            Username = username;
            Summary = summary;
            DateTime = dateTime;
        }
    }
}