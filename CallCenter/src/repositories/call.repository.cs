using System.Data;
using CallCenter.Models;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class CallRepository
    {
        private readonly DatabaseServices _dbService;

        public CallRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        public async Task AddCall(Call call)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            {
                using (SqlCommand command = _dbService.CreateCommand("createNewCall", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.Add(new SqlParameter("@clientId", call.callId));
                    command.Parameters.Add(new SqlParameter("@clientId", call.clientId));
                    command.Parameters.Add(new SqlParameter("@employeeId", call.employeeId));
                    command.Parameters.Add(new SqlParameter("@workId", call.workId));
                    command.Parameters.Add(new SqlParameter("@startTime", call.startTime));
                    command.Parameters.Add(new SqlParameter("@endTime", call.endTime));

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during the execution of the stored procedure.
                        // You may log the exception or take appropriate actions.
                        throw ex;
                    }
                }
            }
        }
    }
}
