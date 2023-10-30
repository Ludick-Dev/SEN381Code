using CallCenter.Database;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CallCenter.DataAccess
{
    public class LoginDataAccess
    {
        //get user credentials
        public (int ID, string Username, string Password) GetUserCredentials(string inputUsername)
        {
            int dbID = 0;
            string dbUsername = "";
            string dbPassword = "";

            DBconnect conString = new DBconnect();
            SqlConnection con = new SqlConnection(conString.connectionString);
            SqlCommand cmd = new SqlCommand("GetUserCredentials", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", inputUsername);

            try
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbID = reader.GetInt32(0);
                        dbUsername = reader.GetString(1);
                        dbPassword = reader.GetString(2);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return (dbID, dbUsername, dbPassword);
        }

        //get user department for redirection to correct page after login
        public string GetUserDepartment(string username)
        {
            string department = string.Empty;
            DBconnect dbconnect = new DBconnect();
            SqlConnection sqlConnection = new SqlConnection(dbconnect.connectionString);
            SqlCommand sqlCommand = new SqlCommand("GetEmployeeDepartment",sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@username", username);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        department = reader.GetString(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return department;
        }
    }
}
