using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using KillerAppSharingPlatform.Classes;
using KillerAppSharingPlatform.Dal.Data;

namespace KillerAppSharingPlatform.Dal.Context
{
    public class SharingSqlContext : ISharingContext
    {
        public List<Topic> GetListTopics()
        {
            List<Topic> topicsList = new List<Topic>();

            const string query = "SELECT * FROM Topic";

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    using (var reader = Database.command.ExecuteReader()) // SqlDataReader
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Read advances to the next row.
                            {
                                topicsList.Add(new Topic(
                                    (int) reader["Id"],
                                    (string) reader["Title"],
                                    (string) reader["Omschrijving"],
                                    (int) reader["Id_Gebruiker"]
                                ));
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
            finally
            {
                Database.CloseConnection();
            }

            return topicsList;
        }

        public void CreateTopic(Topic topic)
        {
            const string query = @"INSERT INTO Topic(Title, Omschrijving, Id_Gebruiker) VALUES (@Title, @Summary, @IdCreator)";

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {
                    
                    Database.command.Parameters.AddWithValue("@Title", topic.Title);
                    Database.command.Parameters.AddWithValue("@Summary", topic.Summary);
                    Database.command.Parameters.AddWithValue("@IdCreator", topic.Id_Gebruiker);
                }
                Database.command.ExecuteNonQuery();
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
        }

        public List<Post> GetListPosts(int id)
        {
            List<Post> lPosts = new List<Post>();

            const string query = "SELECT * FROM Post WHERE Id_Topic = @Id";
            //Database.command.Parameters.AddWithValue("@Id", id);

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                    Database.command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = Database.command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    while (reader.Read())
                    {
                        lPosts.Add(new Post(
                            (int) reader["Id"],
                            (string) reader["Titel"],
                            (string) reader["Inhoud"],
                            (DateTime) reader["Datum"],
                            (int) reader["Id_Topic"],
                            (int) reader["Id_Gebruiker"]
                        ));
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

            return lPosts;

        }

        public void CreatePost(Post post)
        {
            const string query =
                @"INSERT INTO Post(Titel, Inhoud, Id_Gebruiker, Id_Topic, Datum) VALUES (@Title, @Summary, @IdCreator, @IdTopic, @DateTime)";

            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@Title", post.Title);
                    Database.command.Parameters.AddWithValue("@Summary", post.Summary);
                    Database.command.Parameters.AddWithValue("@IdCreator", post.IdCreator);
                    Database.command.Parameters.AddWithValue("@IdTopic", post.IdTopic);
                    Database.command.Parameters.AddWithValue("@DateTime", post.DateTime);
                }
                Database.command.ExecuteNonQuery();
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
        }

        public List<Reaction> GetListReactions(int id)
        {
            List<Reaction> lReactions = new List<Reaction>();

            const string query = "SELECT a.*, c.Gebruikersnaam FROM Reactie a INNER JOIN Gebruiker b ON a.Id_Gebruiker = b.Id INNER JOIN Client c ON b.Id_Client = c.Id WHERE Id_Post = @Id";



            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                    Database.command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = Database.command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    while (reader.Read())
                    {
                        if (reader["Afbeelding"] != DBNull.Value)
                        {
                            lReactions.Add(new Reaction(
                            (int)reader["Id"],
                            (int)reader["Id_Post"],
                            (int)reader["Id_Gebruiker"],
                            (string)reader["Inhoud"],
                            (int)reader["Sterretjes"],
                            (DateTime)reader["Datum"],
                            (string)reader["Afbeelding"],
                            (string)reader["Gebruikersnaam"]
                            ));
                        }
                        else
                        {
                            lReactions.Add(new Reaction(
                            (int)reader["Id"],
                            (int)reader["Id_Post"],
                            (int)reader["Id_Gebruiker"],
                            (string)reader["Inhoud"],
                            (int)reader["Sterretjes"],
                            (DateTime)reader["Datum"],
                            (string)reader["Gebruikersnaam"]
                            ));
                        }
                            

                        
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

            return lReactions;
        }

        public void CreateReaction(Reaction reaction)
        {
            string query = null;

            if (reaction.Image != null)
            {
                query = @"INSERT INTO Reactie(Inhoud, Id_Gebruiker, Id_Post, Datum, Sterretjes, Afbeelding) VALUES (@Summary, @IdCreator, @IdPost, @DateTime, @stars, @afbeelding)";
            }
            else
            {
                query = @"INSERT INTO Reactie(Inhoud, Id_Gebruiker, Id_Post, Datum, Sterretjes) VALUES (@Summary, @IdCreator, @IdPost, @DateTime, @stars)";
            }
            
            
            try
            {
                using (Database.command = new SqlCommand(query, Database.OpenConnection()))
                {

                    Database.command.Parameters.AddWithValue("@IdCreator", reaction.IdCreator);
                    Database.command.Parameters.AddWithValue("@Summary", reaction.Summary);
                    Database.command.Parameters.AddWithValue("@stars", reaction.Stars);
                    Database.command.Parameters.AddWithValue("@DateTime", reaction.DateTime);
                    Database.command.Parameters.AddWithValue("@IdPost", reaction.IdPost);
                    if (reaction.Image != null)
                    {
                        Database.command.Parameters.AddWithValue("@afbeelding", reaction.Image);
                    }
                    Database.command.ExecuteNonQuery();
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
        }
    }
}