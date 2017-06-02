using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSharingPlatform.Classes
{
    public class Client
    {
        public int gebruikerId { get; private set; }
        public string username { get; private set; }

        public string password { get; private set; }
        public string firstname { get; private set; }

        public string lastname { get; private set; }

        public string emailAdress { get; private set; }

        public DateTime birthDay { get; private set; }

        public string role { get; private set; }

        public string street { get; private set; }

        public string houseNumber { get; private set; }
        public string postNumber { get; private set; }
        public string land { get; private set; }
        public string phoneNumber { get; private set; }

        public Client(int gebruikerId, string username,string firstname, string lastname, string emailAdress, DateTime birthDay, string role, string street, string houseNumber, string postNumber, string land, string phoneNumber)
        {
            this.gebruikerId = gebruikerId;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.emailAdress = emailAdress;
            this.birthDay = birthDay;
            this.role = role;
            this.street = street;
            this.houseNumber = houseNumber;
            this.postNumber = postNumber;
            this.land = land;
            this.phoneNumber = phoneNumber;
        }
        public Client(string username, string password, string firstname, string lastname, string emailAdress, DateTime birthDay, string role, string street, string houseNumber, string postNumber, string land, string phoneNumber)
        {
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.emailAdress = emailAdress;
            this.birthDay = birthDay;
            this.role = role;
            this.street = street;
            this.houseNumber = houseNumber;
            this.postNumber = postNumber;
            this.land = land;
            this.phoneNumber = phoneNumber;
        }
        public Client()
        {
            
        }
    }
}