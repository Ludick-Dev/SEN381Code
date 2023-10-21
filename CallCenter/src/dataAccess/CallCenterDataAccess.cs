using CallCenter.Database;
using CallCenter.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace CallCenter.src.dataAccess
{
    public class CallCenterDataAccess
    {
        DBconnect constring = new DBconnect();

        //get technician ID and Name from the DB to display in the dropdown menu in the express work request view form
        public List<string> GetTechnicianDetails()
        {
            List<string> details = new List<string>();
            SqlConnection con = new SqlConnection(constring.connectionString);
            string query = "SELECT t.technicianId, e.employeeName AS technicianName FROM Technicians t JOIN Employees e ON t.employeeId = e.employeeId;";
            SqlCommand cmd = new SqlCommand(query, con);
            string id = string.Empty;
            string name = string.Empty;
            string detailsConcat = string.Empty;    
            try
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         id = reader.GetInt32(0).ToString();
                         name = reader.GetString(1).ToString();
                         detailsConcat = id +": "+ name;
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
            finally
            {
                con.Close();
            }

            return details;
        }

        //get technician email and number based on the technician selected on the express work request form by the user
        public (string email, string number) GetTechnicianContactDetails(string selection)
        {
            string[] idArr = selection.Split(':');
            string  id = idArr[0];
            string dbEmail = string.Empty;
            string dbNumber = string.Empty;

            SqlConnection con = new SqlConnection(constring.connectionString);
            string query = "SELECT e.emailAddress, e.phoneNumber FROM Technicians t JOIN Employees e ON t.employeeId = e.employeeId WHERE t.technicianId = @technicianId; ";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@technicianId", id);

            try
            {
                con.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
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
