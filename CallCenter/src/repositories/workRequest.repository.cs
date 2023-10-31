using System.Data;
using CallCenter.Models;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class WorkRequestRepository
    {
        private readonly DatabaseServices _dbService;

        public WorkRequestRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<WorkRequest>> ExecuteWorkRequestQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<WorkRequest> works = new List<WorkRequest>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            WorkRequest workRequest = new WorkRequest
                            {
                                requestId = reader.GetGuid(reader.GetOrdinal("requestId")),
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                serviceType = reader.GetString(reader.GetOrdinal("serviceType")),
                                priority = reader.GetString(reader.GetOrdinal("priority")),
                                status = reader.GetString(reader.GetOrdinal("status")),
                            };
                            works.Add(workRequest);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return works;
            }
        }

        public async Task AddCall(WorkRequest workRequest)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", workRequest.requestId),
                new SqlParameter("@clientId", workRequest.clientId),
                new SqlParameter("@serviceType", workRequest.serviceType),
                new SqlParameter("@priority", workRequest.priority),
                new SqlParameter("@status", workRequest.status),
            };

            await ExecuteWorkRequestQueryAsync("createWorkRequest", parameters);
        }

        public async Task UpdateWorkRequest(WorkRequest workRequest)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", workRequest.requestId),
                new SqlParameter("@clientId", workRequest.clientId),
                new SqlParameter("@serviceType", workRequest.serviceType),
                new SqlParameter("@priority", workRequest.priority),
                new SqlParameter("@status", workRequest.status),
            };

            await ExecuteWorkRequestQueryAsync("updateWorkRequest", parameters);
        }

        public async Task<List<WorkRequest>> GetAllWorkRequests()
        {
            return await ExecuteWorkRequestQueryAsync("selectAllWorkRequests");
        }

        public async Task GetWorkRequestById(Guid requestId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestId),
            };

            await ExecuteWorkRequestQueryAsync("selectWorkRequestById", parameters);
        }

        public async Task GetWorkRequestByClientId(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId),
            };

            await ExecuteWorkRequestQueryAsync("selectWorkRequestById", parameters);
        }

        public async Task GetWorkRequestByPriority(string priority)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@priority", priority),
            };

            await ExecuteWorkRequestQueryAsync("selectWorkRequestBypriority", parameters);
        }

        public async Task GetWorkRequestByServiceType(string serviceType)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@serviceType", serviceType),
            };

            await ExecuteWorkRequestQueryAsync("selectWorkRequestByserviceType", parameters);
        }

        public async Task GetWorkRequestByStatus(string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@status", status),
            };

            await ExecuteWorkRequestQueryAsync("selectWorkRequestBystatus", parameters);
        }

    }
}