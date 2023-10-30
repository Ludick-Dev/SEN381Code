using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class ClientRepository
    {
        private readonly DatabaseServices _dbService;

        public ClientRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Client>> ExecuteClientQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Client> clients = new List<Client>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Client client = new Client
                            {
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                clientName = reader.GetString(reader.GetOrdinal("clientName")),
                                phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber")),
                                clientType = (ClientTypes)reader.GetInt32(reader.GetOrdinal("clientType")),
                                clientAddress = reader.GetString(reader.GetOrdinal("clientAddress")),
                                lastCallDate = reader.GetDateTime(reader.GetOrdinal("lastCallDate")),
                                requestId = reader.GetGuid(reader.GetOrdinal("requestId")),
                                employeeId = reader.GetGuid(reader.GetOrdinal("employeeId")),
                                clientNotes = reader.GetString(reader.GetOrdinal("clientNotes"))

                            };
                            clients.Add(client);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return clients;
            }
        }
    }
}