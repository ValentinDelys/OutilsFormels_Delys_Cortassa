using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librairie MySQL ajoutée dans les références.
using MySql.Data.MySqlClient;
using System.Windows;

namespace OutilsFormels
{
    public class BDD
    {
        private const string connectionString = "SERVER=localhost; DATABASE=outils_formels; UID=root; PASSWORD=";
        private MySqlConnection connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public BDD()
        {
            initConnection();
        }

        /// <summary>
        /// Init the connection with the database
        /// </summary>
        private void initConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        #region User function
        /// <summary>
        /// Add a User
        /// </summary>
        /// <param name="user"></param>
        public int addUser(User user)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO user ( firstName, lastName, email, password, login) VALUES ( @firstName, @lastName, @email, @password, @login)";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@login", user.login);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButton.OK);
                this.connection.Close();
                return -1;
            }
        }


        public int getUser(string loginUser, ref User user)
        {
            try
            {
                // Ouverture de la connexion SQL(
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                
                // Requête SQL
                cmd.CommandText = "SELECT * FROM user WHERE login = " + (char)34 + loginUser + (char)34;
                // Exécution de la commande SQL
                Console.WriteLine(cmd.CommandText);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                    else
                    {
                        throw new Exception("User doesn't exist in the database");
                    }

                }

                // Fermeture de la connexion
                this.connection.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButton.OK);
                this.connection.Close();
                return -1;
            }
        }

        /// <summary>
        /// Delete a user in the database
        /// </summary>
        /// <param name="loginUser">User delete</param>
        /// <returns></returns>
        public int deleteUser(string loginUser)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "DELETE FROM user WHERE login = " + (char)34 + loginUser + (char)34;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButton.OK);
                this.connection.Close();
                return -1;
            }
        }
        #endregion

        #region Card Function
        /// <summary>
        /// Add a card in the database
        /// </summary>
        /// <param name="card"> Card class </param>
        public int addCard(Card card)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO card ( number, expiration, type, fk_userID) VALUES ( @number, @expiration, @type, @fk_userID)";

                // Utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@number", card.number);
                cmd.Parameters.AddWithValue("@expiration", card.expiration);
                cmd.Parameters.AddWithValue("@type", card.type);
                cmd.Parameters.AddWithValue("@fk_userID", card.fk_userID);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButton.OK);
                return -1;
            }
        }

        /// <summary>
        /// Delete a card from the database
        /// </summary>
        /// <param name="cardID"> ID of the card which must be deleted</param>
        /// <returns></returns>
        public int deleteCard(int cardID)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "DELETE FROM card WHERE card.cardID = " + cardID;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButton.OK);
                return -1;
            }
        }

        /// <summary>
        /// Get all cards from the database
        /// </summary>
        /// <param name="user">User class</param>
        /// <param name="list">List class</param>
        /// <returns></returns>
        public int getAllCards(ref User user, ref List<Card> list)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "SELECT * FROM card WHERE fk_userID = " + user.userID;
                
                // Exécution de la commande SQL
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Card card = new Card(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4));
                            list.Add(card);
                        }
                    }

                }

                // Fermeture de la connexion
                this.connection.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButton.OK);

                return -1;
            }
        }

        #endregion
    }
}
