using CallCenter.Database;
using CallCenter.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CallCenter.DataAccess
{
    public class RequestLogDataAccess
    {
        DBconnect connection = new DBconnect();

        //display all request logs 
        public List<RequestLog> DisplayAllRequestLogs()
        {
            SqlConnection con = new SqlConnection(connection.connectionString);
            SqlCommand cmd = new SqlCommand("GetAllRequestLogs", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            List<RequestLog> logs = new List<RequestLog>();

            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RequestLog log = new RequestLog();
                        log.clientId = reader.GetGuid(0);
                        log.clientName = reader.GetString(1);
                        log.lastCallDate = reader.GetDateTime(2);
                        log.callDuration = reader.GetInt32(3);
                        log.requestId = reader.GetGuid(4);
                        log.technicianName = reader.GetString(5);
                        log.priorityLevel = reader.GetString(6);
                        log.status = reader.GetString(7);

                        logs.Add(log);
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

            return logs;
        }

        //search and display request log via client name or request ID
        public RequestLog SearchRequestLog(string? clientName, int? requestId)
        {
            RequestLog log = new RequestLog();
            SqlConnection con = new SqlConnection(connection.connectionString);
            SqlCommand cmd = new SqlCommand("SearchRequestLog", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (clientName != null)
            {
                cmd.Parameters.AddWithValue("@clientName", clientName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@clientName", DBNull.Value);
            }

            if (requestId != null)
            {
                cmd.Parameters.AddWithValue("@requestId", requestId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@requestId", DBNull.Value);
            }

            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        log.clientId = reader.GetGuid(0);
                        log.clientName = reader.GetString(1);
                        log.lastCallDate = reader.GetDateTime(2);
                        log.callDuration = reader.GetInt32(3);
                        log.requestId = reader.GetGuid(4);
                        log.technicianName = reader.GetString(5);
                        log.priorityLevel = reader.GetString(6);
                        log.status = reader.GetString(7);
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

            return log;
        }
    }
}
