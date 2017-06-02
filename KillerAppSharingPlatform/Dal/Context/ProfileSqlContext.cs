using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Classes;
using KillerAppSharingPlatform.Classes;
using KillerAppSharingPlatform.Dal.Data;

namespace KillerAppSharingPlatform.Dal.Context
{
    public class ProfileSqlContext : IProfileContext
    {
        public int userIdFromUserName { get; private set; }

        public bool AddFriend(string username, int userId)
        {
            bool succesfull = false;
            const string queryGetId = @"SELECT a.Id FROM Gebruiker a INNER JOIN Client b ON a.Id_Client = b.Id WHERE b.Gebruikersnaam = @username";
            const string addFriend = @"INSERT INTO Vriend (Id_Gebruiker, Id_Vriend) Values(@IdGebruiker, @IdVriend)";
            getUserId(queryGetId, username);
            try
            {
                
                Database.command.ExecuteNonQuery();

                using (Database.command = new SqlCommand(addFriend, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@IdGebruiker", userId);
                    Database.command.Parameters.AddWithValue("@IdVriend", userIdFromUserName);
                }
                Database.command.ExecuteNonQuery();
                succesfull = true;

            }
            catch (Exception e)
            {
                succesfull = false;
            }

            return succesfull;
        }

        public void AcceptFriend(string username, int userId)
        {
           
            const string query = @"SELECT a.Id FROM Gebruiker a INNER JOIN Client b ON a.Id_Client = b.Id WHERE b.Gebruikersnaam = @username";
            const string queryaccept = @"UPDATE Vriend SET Geaccepteerd = 'Accepted' WHERE Id_Gebruiker = @gebruikerId And Id_Vriend = @vriendId";
            getUserId(query, username);

            try
            {
                using (Database.command = new SqlCommand(queryaccept, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@gebruikerId", userIdFromUserName);
                    Database.command.Parameters.AddWithValue("@vriendId", userId);
                }
                Database.command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddBlock(string username, int userId)
        {

            const string query = @"";

            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddFollow(string username, int userId)
        {
            bool succesfull = false;
            const string query = @"";

            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SendMessage(Message message)
        {

            const string query = @"INSERT INTO Bericht(Id_Gebruiker_Ontvanger, Id_Gebruiker_Verzender, Inhoud, Datum) VALUES (@IdOntvanger, @IdVerzender, @summary, @DateTime)";
            const string querygetid = @"SELECT a.Id FROM Gebruiker a INNER JOIN Client b ON a.Id_Client = b.Id WHERE b.Gebruikersnaam = @username";
            getUserId(querygetid, message.Username);
            try
            {
                using(Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@IdOntvanger", userIdFromUserName);
                    Database.command.Parameters.AddWithValue("@IdVerzender", message.IdSender);
                    Database.command.Parameters.AddWithValue("@summary", message.Summary);
                    Database.command.Parameters.AddWithValue("@DateTime", message.DateTime);
                  
                    Database.command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<string> LUserList()
        {
            List<string> luserlist = new List<string>();
            const string query = @"";
            throw new NotImplementedException();
        }

        public List<string> LFriendList(int IdGebruiker, string Gebruikersnaam)
        {
            List<string> lfriendlist = new List<string>();
            const string query = @"SELECT DISTINCT Gebruikersnaam FROM Client a INNER JOIN Gebruiker b ON a.Id = b.Id_Client INNER JOIN Vriend c ON b.Id = c.Id_Vriend or b.Id = c.Id_Gebruiker WHERE (c.Id_Gebruiker= @IdGebruiker OR c.Id_Vriend = @IdGebruiker) AND (c.Geaccepteerd = 'Accepted')";

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@IdGebruiker", IdGebruiker);

                    using (var reader = Database.command.ExecuteReader()) // SqlDataReader
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Read advances to the next row.
                            {
                                if ((string) reader["Gebruikersnaam"] != Gebruikersnaam)
                                {
                                    string username = (string)reader["Gebruikersnaam"];
                                    lfriendlist.Add(username);
                                }
                                
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return lfriendlist;
        }

        public List<string> LFriendPendingList(int IdGebruiker)
        {
            List<string>lfriendpendinglist = new List<string>();
            const string query = @"SELECT Gebruikersnaam FROM Client a INNER JOIN Gebruiker b ON a.Id = b.Id_Client INNER JOIN Vriend c ON b.Id = c.Id_Gebruiker WHERE c.Id_Vriend= @IdGebruiker AND c.Geaccepteerd = 'Pending'";

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@IdGebruiker", IdGebruiker);

                    using (var reader = Database.command.ExecuteReader()) // SqlDataReader
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Read advances to the next row.
                            {
                                string username = (string)reader["Gebruikersnaam"];
                                lfriendpendinglist.Add(username);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return lfriendpendinglist;
        }

        public List<string> LBlockList(int IdGebruiker)
        {
            List<string> lblocklist = new List<string>();
            const string query = @"";
            throw new NotImplementedException();
        }

        public List<string> LFollowList(int IdGebruiker)
        {
            List<string> lfollowlist = new List<string>();
            const string query = @"";
            throw new NotImplementedException();
        }

        public void getUserId(string query, string username)
        {
            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@username", username);

                    using (var reader = Database.command.ExecuteReader()) // SqlDataReader
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Read advances to the next row.
                            {
                                userIdFromUserName = (int)reader["Id"];

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Message> LmessageList(int IdOntvanger)
        {
            List<Message> lmessagelist = new List<Message>();

            const string query = @"SELECT a.*, c.Gebruikersnaam as Gebruikersnaam FROM Bericht a INNER JOIN Gebruiker b ON a.Id_Gebruiker_Verzender = b.Id INNER JOIN Client c ON b.Id_Client = c.Id WHERE a.Id_Gebruiker_Ontvanger = @IdOntvanger";
            

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@IdOntvanger", IdOntvanger);

                    using (var reader = Database.command.ExecuteReader()) // SqlDataReader
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Read advances to the next row.
                            {

                                DateTime datetime = DateTime.Now;
                                int berichtId = (int) reader["Id"];
                                int sender = (int)reader["Id_Gebruiker_Verzender"];
                                string username = (string)reader["Gebruikersnaam"];
                                string summary = (string)reader["Inhoud"];
                                if (reader["Datum"] != DBNull.Value)
                                {
                                    datetime = (DateTime)(reader["Datum"]);
                                }

                                

                                Message message = new Message(berichtId,sender, username, summary, datetime);
                                
                                lmessagelist.Add(message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return lmessagelist;
        }
    }
}