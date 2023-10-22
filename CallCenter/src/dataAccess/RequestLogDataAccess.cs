using CallCenter.Models;
using CallCenter.Database;
using CallCenter.src.models;
using Microsoft.Data.SqlClient;

namespace CallCenter.src.dataAccess
{
    public class RequestLogDataAccess
    {
        DBconnect connection = new DBconnect();

         //display all request logs 
        public List<requestLog> DisplayAllRequestLogs()
        {
            SqlConnection con = new SqlConnection(connection.connectionString);
            string query = "SELECT c.clientId, c.clientName, c.lastCallDate, DATEDIFF(MINUTE, ca.startTime, ca.endTime) AS callDuration, wr.requestId, e.employeeName AS technicianName, ca.PriorityLevel, wr.status FROM Clients c JOIN Calls ca ON c.clientId = ca.clientId JOIN Work w ON ca.workId = w.workId JOIN Technicians t ON w.technicianId = t.technicianId JOIN Employees e ON t.employeeId = e.employeeId JOIN WorkRequests wr ON w.requestId = wr.requestId";
            SqlCommand cmd = new SqlCommand(query, con);
            List<requestLog> logs = new List<requestLog>();

            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        requestLog log = new requestLog();
                        log.clientId = reader.GetInt32(0);
                        log.clientName = reader.GetString(1);
                        log.lastCallDate = reader.GetDateTime(2);
                        log.callDuration = reader.GetInt32(3);
                        log.requestId = reader.GetInt32(4);
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
        public requestLog SearchRequestLog(string? clientName, int? requestId)
        {
            requestLog log = new requestLog();
            SqlConnection con = new SqlConnection(connection.connectionString);
            string query = "SELECT c.clientId, c.clientName, c.lastCallDate, DATEDIFF(MINUTE, ca.startTime, ca.endTime) AS callDuration, wr.requestId, e.employeeName AS technicianName, ca.PriorityLevel, wr.status FROM Clients c JOIN Calls ca ON c.clientId = ca.clientId JOIN Work w ON ca.workId = w.workId JOIN Technicians t ON w.technicianId = t.technicianId JOIN Employees e ON t.employeeId = e.employeeId JOIN WorkRequests wr ON w.requestId = wr.requestId WHERE c.clientName = @clientName OR wr.requestId = @requestId";
            SqlCommand cmd = new SqlCommand(query, con);

            if (clientName != null)
            {
                cmd.Parameters.AddWithValue("@clientName", clientName);
            }
            if (requestId != null)
            {
                cmd.Parameters.AddWithValue("@requestId", requestId);
            }

            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        log.clientId = reader.GetInt32(0);
                        log.clientName = reader.GetString(1);
                        log.lastCallDate = reader.GetDateTime(2);
                        log.callDuration = reader.GetInt32(3);
                        log.requestId = reader.GetInt32(4);
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
