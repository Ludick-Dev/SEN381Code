using CallCenter.Database;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CallCenter.DataAccess
{
    public class CallCenterDataAccess
    {
        DBconnect constring = new DBconnect();

        //get technician ID and Name from the DB to display in the dropdown menu in the express work request view form
        public List<string> GetTechnicianDetails()
        {
            List<string> details = new List<string>();
            using (SqlConnection con = new SqlConnection(constring.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetTechnicianDetails", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["technicianId"].ToString();
                            string name = reader["technicianName"].ToString();
                            string detailsConcat = id + ": " + name;
                            details.Add(detailsConcat);
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
            }

            return details;
        }

        //get technician email and number based on the technician selected on the express work request form by the user
        public (string email, string number) GetTechnicianContactDetails(string selection)
        {
            string[] idArr = selection.Split(':');
            string id = idArr[0];
            string dbEmail = string.Empty;
            string dbNumber = string.Empty;

            SqlConnection con = new SqlConnection(constring.connectionString);
            SqlCommand sqlCommand = new SqlCommand("GetTechnicianContactInfo", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@technicianId", id);

            try
            {
                con.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dbEmail = reader.GetString(0);
                        dbNumber = reader.GetString(1);
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

            return (dbEmail, dbNumber);
        }
    }
}
