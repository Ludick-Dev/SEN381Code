using System.Data;
using CallCenter.Models;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class RequestLogRepository
    {
        private readonly DatabaseServices _dbService;

        public RequestLogRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<RequestLog>> ExecuteRequestLogQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<RequestLog> requestLogs = new List<RequestLog>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            RequestLog requestLog = new RequestLog
                            {
                                requestId = reader.GetGuid(reader.GetOrdinal("requestId")),
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                clientName = reader.GetString(reader.GetOrdinal("clientName")),
                                lastCallDate = reader.GetDateTime(reader.GetOrdinal("lastCallDate")),
                                callDuration = reader.GetDouble(reader.GetOrdinal("callDuration")),
                                technicianName = reader.GetString(reader.GetOrdinal("technicianName")),
                                priorityLevel = reader.GetString(reader.GetOrdinal("priorityLevel")),
                                status = reader.GetString(reader.GetOrdinal("status"))

                            };
                            requestLogs.Add(requestLog);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return requestLogs;
            }
        }

        public async Task AddRequestLog(RequestLog requestLog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestLog.requestId),
                new SqlParameter("@clientId", requestLog.clientId),
                new SqlParameter("@clientName", requestLog.clientName),
                new SqlParameter("@lastCallDate", requestLog.lastCallDate),
                new SqlParameter("@callDuration", requestLog.callDuration),
                new SqlParameter("@technicianName", requestLog.technicianName),
                new SqlParameter("@priorityLevel", requestLog.priorityLevel),
                new SqlParameter("@status", requestLog.status),
            };

            await ExecuteRequestLogQueryAsync("createRequestLog", parameters);
        }

        public async Task UpdateRequestLog(RequestLog requestLog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestLog.requestId),
                new SqlParameter("@clientId", requestLog.clientId),
                new SqlParameter("@clientName", requestLog.clientName),
                new SqlParameter("@lastCallDate", requestLog.lastCallDate),
                new SqlParameter("@callDuration", requestLog.callDuration),
                new SqlParameter("@technicianName", requestLog.technicianName),
                new SqlParameter("@priorityLevel", requestLog.priorityLevel),
                new SqlParameter("@status", requestLog.status),
            };

            await ExecuteRequestLogQueryAsync("updateRequestLog", parameters);
        }

        public async Task<List<RequestLog>> GetAllRequestLogs()
        {
            return await ExecuteRequestLogQueryAsync("selectAllRequestLogs");
        }

        public async Task GetRequestLogById(Guid requestId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestId),
            };

            await ExecuteRequestLogQueryAsync("selectRequestLogById", parameters);
        }

        public async Task GetRequestLogByClinetId(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId),
            };

            await ExecuteRequestLogQueryAsync("selectRequestLogByClientId", parameters);
        }

        public async Task GetRequestLogByClientName(string clientName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientName", clientName),
            };

            await ExecuteRequestLogQueryAsync("selectRequestLogByClientName", parameters);
        }

        public async Task GetRequestLogByTechnicianName(string technicianName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@technicianName", technicianName),
            };

            await ExecuteRequestLogQueryAsync("selectRequestLogByTechnicianName", parameters);
        }

        public async Task GetRequestLogtByStatus(string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@status", status),
            };

            await ExecuteRequestLogQueryAsync("selecRequestLogByStatus", parameters);
        }

    }
}