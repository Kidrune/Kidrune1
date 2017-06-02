using KillerAppSharingPlatform.Dal.Context;
using KillerAppSharingPlatform.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace KillerAppSharingPlatform.Controllers
{
    [RequireHttps]
    
    public class HomeController : Controller
    {
        readonly AccountSqlContext accountSqlContext = new AccountSqlContext();

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Bericht()
        {
            ViewBag.TheMessage = "";
            return View();
        }

        [HttpPost]
        public ActionResult Bericht(string message)
        {
            

            ViewBag.TheMessage = "Thank you";
            return View();
        }

        public ActionResult Login()
        {




            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Client client;
            bool succesfull = accountSqlContext.LoginUser(username, password);

            if (succesfull)
            {
                
                client = accountSqlContext.GetUserCredentials(username);
                Session["GebruikerId"] = client.gebruikerId;
                Session["Gebruikersnaam"] = client.username;
                Session["Voornaam"] = client.firstname;
                Session["Achternaam"] = client.lastname;
                Session["EmailAdress"] = client.emailAdress;
                Session["Geboortedatum"] = client.birthDay;
                Session["Rol"] = client.role;
                Session["Straat"] = client.street;
                Session["Huisnummer"] = client.houseNumber;
                Session["PostCode"] = client.postNumber;
                Session["Land"] = client.land;
                Session["Telefoonnummer"] = client.phoneNumber;

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.login = "Gebruikersnaam of wachtwoord is incorrect";
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string firstname, string lastname, string email, DateTime birthday, string role, string street, string housenumber, string postcode, string land, string phonenumber)
        {
            bool succesfull = false;
            Client client = new Client(username, password, firstname, lastname, email, birthday, role, street, housenumber, postcode, land, phonenumber);

            succesfull = accountSqlContext.RegisterUser(client);

            if (succesfull)
            {
                Response.AddHeader("REFRESH", "5;URL=login");
                ViewBag.succes = "Registratie voltooid. Binnen vijf seconden wordt je doorgestuurd naar de login pagina.";
            }
            else
            {
                
                ViewBag.register = "Incorrecte gegevens, registratie mislukt.";
            }


            return View();
        }

        public ActionResult Logoff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NoPermission()
        {
            return View("ErrorPermission");
        }
    }
}