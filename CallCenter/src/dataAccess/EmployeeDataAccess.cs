using Amazon.Auth.AccessControlPolicy.ActionIdentifiers;
using CallCenter.Database;
using CallCenter.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CallCenter.src.dataAccess
{
    public class EmployeeDataAccess
    {
        DBconnect con = new DBconnect();
        
        //display all employees
        public List<Employee> DisplayAllEmployees() 
        {
            SqlConnection connection = new SqlConnection(con.connectionString);
            string query = "SELECT * FROM Employees";
            SqlCommand cmd = new SqlCommand(query, connection);
            List<Employee> employeeDetails = new List<Employee>();
            try
            {
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.employeeId = reader.GetInt32(0);
                        employee.employeeName = reader.GetString(1);
                        employee.department = reader.GetString(2);
                        employee.availability = reader.GetBoolean(3);
                        employee.serviceArea = reader.GetString(4);
                        employee.certificationLevel = reader.GetString(5);
                        employee.emailAddress = reader.GetString(6);
                        employee.phoneNumber = reader.GetString(7);

                        employeeDetails.Add(employee);
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
                connection.Close();
            }

            return employeeDetails;
        }

        //remove an employee via ID
        public void RemoveEmployee(int employeeID)
        {
            SqlConnection connection = new SqlConnection(con.connectionString);
            SqlCommand cmd = new SqlCommand("RemoveEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeId", employeeID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
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
                connection.Close();
            }
        }

        //add new employee
        public void AddNewEmployee(string employeeName, string department, bool availability, string serviceArea, string certificationLevel, string emailAddress, string phoneNumber)
        {
            SqlConnection sqlConnection = new SqlConnection(con.connectionString);
            SqlCommand cmd = new SqlCommand("AddEmployee", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeName", employeeName);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@availability", availability);
            cmd.Parameters.AddWithValue("@serviceArea", serviceArea);
            cmd.Parameters.AddWithValue("@certificationLevel", certificationLevel);
            cmd.Parameters.AddWithValue("@emailAddress", emailAddress);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

            try
            {
                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee added successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not successfully added.");
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
        }

        //edit employee details
        public void EditEmployee(int employeeId, string employeeName, string department, bool availability, string serviceArea, string certificationLevel, string emailAddress, string phoneNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(con.connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@employeeName", employeeName);
                cmd.Parameters.AddWithValue("@department", department);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@serviceArea", serviceArea);
                cmd.Parameters.AddWithValue("@certificationLevel", certificationLevel);
                cmd.Parameters.AddWithValue("@emailAddress", emailAddress);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                try
                {
                    sqlConnection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Employee updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Employee not updated successfully.");
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
        }

        //search for employee via ID or name
        public Employee SearchEmployee(int? employeeId, string? employeeName)
        {
            SqlConnection sqlConnection = new SqlConnection(con.connectionString);
            SqlCommand cmd = new SqlCommand("SearchEmployee", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            Employee employee = new Employee();

            cmd.Parameters.AddWithValue("@employeeId", (object)employeeId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@employeeName", (object)employeeName ?? DBNull.Value);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    employee.employeeId = reader.GetInt32(0);
                    employee.employeeName = reader.GetString(1);
                    employee.department = reader.IsDBNull(2) ? null : reader.GetString(2);
                    employee.availability = reader.GetBoolean(3);
                    employee.serviceArea = reader.IsDBNull(4) ? null : reader.GetString(4);
                    employee.certificationLevel = reader.IsDBNull(5) ? null : reader.GetString(5);
                    employee.emailAddress = reader.IsDBNull(6) ? null : reader.GetString(6);
                    employee.phoneNumber = reader.IsDBNull(7) ? null : reader.GetString(7);
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

            return employee;
        }
    }
    
}
