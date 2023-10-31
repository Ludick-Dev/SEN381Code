using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class EmployeeRepository
    {
        private readonly DatabaseServices _dbService;

        public EmployeeRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Employee>> ExecuteEmployeeQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Employee> employees = new List<Employee>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Employee employee = new Employee
                            {
                                employeeId = reader.GetGuid(reader.GetOrdinal("employeeId")),
                                employeeName = reader.GetString(reader.GetOrdinal("employeeName")),
                                department = (Department)reader.GetInt32(reader.GetOrdinal("department")),
                                availability = reader.GetBoolean(reader.GetOrdinal("availability")),
                                serviceArea = reader.GetString(reader.GetOrdinal("serviceArea")),
                                certificationLevel = reader.GetString(reader.GetOrdinal("certificationLevel")),
                                emailAddress = reader.GetString(reader.GetOrdinal("emailAddress")),
                                phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber")),

                            };
                            employees.Add(employee);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return employees;
            }
        }

        public async Task AddEmployee(Employee employee)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", employee.employeeId),
                new SqlParameter("@employeeName", employee.employeeName),
                new SqlParameter("@department", employee.department),
                new SqlParameter("@availability", employee.availability),
                new SqlParameter("@serviceArea", employee.serviceArea),
                new SqlParameter("@certificationLevel", employee.certificationLevel),
                new SqlParameter("@emailAddress", employee.emailAddress),
                new SqlParameter("@phoneNumber", employee.phoneNumber),
            };

            await ExecuteEmployeeQueryAsync("createEmployee", parameters);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", employee.employeeId),
                new SqlParameter("@employeeName", employee.employeeName),
                new SqlParameter("@department", employee.department),
                new SqlParameter("@availability", employee.availability),
                new SqlParameter("@serviceArea", employee.serviceArea),
                new SqlParameter("@certificationLevel", employee.certificationLevel),
                new SqlParameter("@emailAddress", employee.emailAddress),
                new SqlParameter("@phoneNumber", employee.phoneNumber),
            };

            await ExecuteEmployeeQueryAsync("updateEmployee", parameters);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await ExecuteEmployeeQueryAsync("selectAllClients");
        }

        public async Task GetEmployeeById(Guid employeeId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", employeeId),
            };

            await ExecuteEmployeeQueryAsync("selectEmployeeById", parameters);
        }

        public async Task GetEmployeeByName(string employeeName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeName", employeeName),
            };

            await ExecuteEmployeeQueryAsync("selectEmployeeByName", parameters);
        }

        public async Task GetEmployeeByPhoneNumber(string phoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@phoneNumber", phoneNumber),
            };

            await ExecuteEmployeeQueryAsync("selectClientByPhone", parameters);
        }

    }
}