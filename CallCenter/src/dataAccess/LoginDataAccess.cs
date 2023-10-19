using CallCenter.Database;
using Microsoft.Data.SqlClient;

namespace CallCenter.DataAccess
{
    public class LoginDataAccess
    {
        public (int ID, string Username, string Password) GetUserCredentials(string inputUsername)
        {
            int dbID = 0;
            string dbUsername = "";
            string dbPassword = "";

            DBconnect conString = new DBconnect();
            SqlConnection con = new SqlConnection(conString.connectionString);
            string query = "SELECT employeeId, username, password FROM EmployeeLogin WHERE username = @Username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", inputUsername);

            try
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbID = reader.GetInt32(0);
                        dbUsername = reader.GetString(1).ToString();
                        dbPassword = reader.GetString(2).ToString();
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
    }
}
