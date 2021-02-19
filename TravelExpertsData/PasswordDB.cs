using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PasswordDB
    {
        public static bool Authenticate(string submittedPassword)
        {
            bool isMatch;
            string mostRecentPassword = "password from database";

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT Passwords FROM GUI_Password WHERE PasswordId = (SELECT MAX(PasswordId) FROM GUI_Password)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            mostRecentPassword = (string)dr["Passwords"];
                        }
                    }
                }
            }

            isMatch = submittedPassword.Equals(mostRecentPassword);
            return isMatch;
        }

        public static string GetHint()
        {
            string hint = "hint from database";

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT Hint FROM GUI_Password WHERE PasswordId = (SELECT MAX(PasswordId) FROM GUI_Password)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            hint = (string)dr["Hint"];
                        }
                    }
                }
            }

            return hint;
        }

        public static DateTime GetLastUpdateDate()
        {
            DateTime lastUpdateDate = DateTime.Today;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT UpdateDate FROM GUI_Password WHERE PasswordId = (SELECT MAX(PasswordId) FROM GUI_Password)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            lastUpdateDate = (DateTime)dr["UpdateDate"];
                        }
                    }
                }
            }

            return lastUpdateDate;
        }

        public static bool HasPasswordAlreadyBeenUsed(string newPassword)
        {
            bool isAlreadyUsed = true;
            List<string> oldPasswords = new List<string>();

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT Passwords FROM GUI_Password";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            string oldPassword = (string)dr["Passwords"];

                            oldPasswords.Add(oldPassword);
                        }
                    }
                }
            }

            isAlreadyUsed = oldPasswords.Contains(newPassword);

            return isAlreadyUsed;
        }

        public static bool UpdatePassword(Password password)
        {
            bool successfullyAdded = false;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement = "INSERT INTO GUI_Password (Passwords, Hint, UpdateDate) " +
                                         "OUTPUT INSERTED.PasswordId " +
                                         "VALUES (@Passwords, @Hint, @UpdateDate)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@Passwords", password.PasswordInput);
                    cmd.Parameters.AddWithValue("@Hint", password.Hint);
                    cmd.Parameters.AddWithValue("@UpdateDate", password.UpdateDate);

                    connection.Open();

                    if (cmd.ExecuteNonQuery() == 1)
                        successfullyAdded = true;
                    else
                        successfullyAdded = false;
                }
            }

            return successfullyAdded;
        }
    }
}
