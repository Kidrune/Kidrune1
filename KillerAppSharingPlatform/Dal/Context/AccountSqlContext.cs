using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerAppSharingPlatform.Classes;
using KillerAppSharingPlatform.Dal.Data;
using System.Data.SqlClient;

namespace KillerAppSharingPlatform.Dal.Context
{
    public class AccountSqlContext : IAccountContext
    {
        public bool LoginUser(string username, string password)
        {
            bool loginSuccesfull = false;
            const string query = "SELECT * FROM Client WHERE Gebruikersnaam = @username AND Password = @password";

            

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                    Database.command.Parameters.AddWithValue("@username", username);
                    Database.command.Parameters.AddWithValue("@password", password);
                using (SqlDataReader reader = Database.command.ExecuteReader())
                {
                    if (!reader.HasRows) return false;

                    while (reader.Read())
                    {
                        loginSuccesfull = true;
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Database.CloseConnection();
            }
            return loginSuccesfull;
        }

        public bool RegisterUser(Client client)
        {
            bool succesfull = false;
            const string query = @"INSERT INTO Client(Gebruikersnaam, Password, Voornaam, Achternaam, EmailAdress, Geboortedatum, Rol, Straat, Huisnummer, Land, Telefoonnummer, Postcode) VALUES (@Gebruikersnaam, @Password, @Voornaam, @Achternaam, @EmailAdress, @Geboortedatum, @Rol, @Straat, @Huisnummer, @Land, @Telefoonnummer, @Postcode)";

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@Gebruikersnaam", client.username);
                    Database.command.Parameters.AddWithValue("@Password", client.password);
                    Database.command.Parameters.AddWithValue("@Voornaam", client.firstname);
                    Database.command.Parameters.AddWithValue("@Achternaam", client.lastname);
                    Database.command.Parameters.AddWithValue("@EmailAdress", client.emailAdress);
                    Database.command.Parameters.AddWithValue("@Geboortedatum", client.birthDay);
                    Database.command.Parameters.AddWithValue("@Rol", client.role);
                    Database.command.Parameters.AddWithValue("@Straat", client.street);
                    Database.command.Parameters.AddWithValue("@Huisnummer", client.houseNumber);
                    Database.command.Parameters.AddWithValue("@Land", client.land);
                    Database.command.Parameters.AddWithValue("@Telefoonnummer", client.phoneNumber);
                    Database.command.Parameters.AddWithValue("@Postcode", client.postNumber);

                    
                }
                Database.command.ExecuteNonQuery();
                succesfull = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



            return succesfull;
            

        }

        public Client GetUserCredentials(string username)
        {
            Client client = new Client();

            string rol = null;
            const string getrole = @"Select Rol FROM Client WHERE Gebruikersnaam = @username";

            using (Database.command = new SqlCommand(getrole, Database.OpenConnection()))
                Database.command.Parameters.AddWithValue("@username", username);
            using (SqlDataReader reader = Database.command.ExecuteReader())
            {
                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    rol = (string) reader["Rol"];
                }
            }

            
            string query = "SELECT a.*, b.Id as GebruikerId FROM Client a INNER JOIN Gebruiker b ON a.Id =  b.Id_Client WHERE Gebruikersnaam = @username";

            if (rol == "Administrator")
            {
                query = "SELECT a.*, b.Id as GebruikerId FROM Client a INNER JOIN Administrator b ON a.Id =  b.Id_Client WHERE Gebruikersnaam = @username";
            }

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                    Database.command.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = Database.command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    while (reader.Read())
                    {
                        string userid = null;
                        if ((string) reader["Rol"] == "User")
                        {
                            userid = "GebruikerId";
                        }
                        if ((string) reader["Rol"] == "Administrator")
                        {
                            userid = "AdminId";
                        }
                        client = new Client(
                        
                            (int)reader["GebruikerId"],
                            (string)reader["Gebruikersnaam"],
                            (string)reader["Voornaam"],
                            (string)reader["Achternaam"],
                            (string)reader["EmailAdress"],
                            (DateTime)reader["Geboortedatum"],
                            (string)reader["Rol"],
                            (string)reader["Straat"],
                            (string)reader["Huisnummer"],
                            (string)reader["PostCode"],
                            (string)reader["Land"],
                            (string)reader["Telefoonnummer"]

                        );
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return client;
        }
    }
}