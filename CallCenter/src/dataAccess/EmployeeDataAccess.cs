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
            string query = "DELETE FROM Employees WHERE employeeId = @employeeId;";
            SqlCommand cmd = new SqlCommand(query, connection);
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
            string query = "INSERT INTO Employees (employeeName, department, availability, serviceArea, certificationLevel, emailAddress, phoneNumber) VALUES (@employeeName, @department, @availability, @serviceArea, @certificationLevel, @emailAddress, @phoneNumber);";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
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
            SqlConnection sqlConnection = new SqlConnection(con.connectionString);
            string query = "UPDATE Employees SET employeeName = @employeeName, department = @department, availability = @availability, serviceArea = @serviceArea, certificationLevel = @certificationLevel, emailAddress = @emailAddress, phoneNumber = @phoneNumber WHERE employeeId = @employeeId;";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
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
            finally
            {
                  sqlConnection.Close();
            }
        }

        //search for employee via ID or name
        public Employee SearchEmployee(int? employeeId, string? employeeName)
        {
            SqlConnection sqlConnection = new SqlConnection(con.connectionString);
            string query = "SELECT * FROM Employees WHERE employeeId = @employeeId OR employeeName = @employeeName;";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            Employee employee = new Employee();

            if (employeeId != null)
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
            }

            if (employeeName != null) 
            {
                cmd.Parameters.AddWithValue("@employeeName", employeeName);
            }

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    employee.employeeId = reader.GetInt32(0);
                    employee.employeeName = reader.GetString(1);
                    employee.department = reader.GetString(2);
                    employee.availability = reader.GetBoolean(3);
                    employee.serviceArea = reader.GetString(4);
                    employee.certificationLevel = reader.GetString(5);
                    employee.emailAddress = reader.GetString(6);
                    employee.phoneNumber = reader.GetString(7);
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
