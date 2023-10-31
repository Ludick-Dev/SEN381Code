using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class ContractRepository
    {
        private readonly DatabaseServices _dbService;

        public ContractRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Contract>> ExecuteContractQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Contract> contracts = new List<Contract>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Contract contract = new Contract
                            {
                                contractId = reader.GetGuid(reader.GetOrdinal("contractId")),
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                contractType = (ContractType)reader.GetInt32(reader.GetOrdinal("contractType")),
                                contractDetails = reader.GetString(reader.GetOrdinal("contractDetails")),
                                serviceLevel = reader.GetInt32(reader.GetOrdinal("serviceLevel")),
                                contractStatus = (ContractStatus)reader.GetInt32(reader.GetOrdinal("contractStatus")),

                            };
                            contracts.Add(contract);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return contracts;
            }
        }

        public async Task AddContract(Contract contract)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractID", contract.contractId),
                new SqlParameter("@clientId", contract.clientId),
                new SqlParameter("@contractType", contract.contractType),
                new SqlParameter("@contractDetails", contract.contractDetails),
                new SqlParameter("@serviceLevel", contract.serviceLevel),
                new SqlParameter("@contractStatus", contract.contractStatus),
            };

            await ExecuteContractQueryAsync("createContract", parameters);
        }

        public async Task UpdateClient(Contract contract)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractID", contract.contractId),
                new SqlParameter("@clientId", contract.clientId),
                new SqlParameter("@contractType", contract.contractType),
                new SqlParameter("@contractDetails", contract.contractDetails),
                new SqlParameter("@serviceLevel", contract.serviceLevel),
                new SqlParameter("@contractStatus", contract.contractStatus),
            };

            await ExecuteContractQueryAsync("updateContract", parameters);
        }

        public async Task GetContractById(Guid contractId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractId", contractId),
            };

            await ExecuteContractQueryAsync("selectContractById", parameters);
        }

        public async Task GetContractByClientId(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId),
            };

            await ExecuteContractQueryAsync("selectContractByClientId", parameters);
        }

        public async Task GetContractByServiceLevel(int serviceLevel)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@serviceLevel", serviceLevel),
            };

            await ExecuteContractQueryAsync("selectContractByServiceLevel", parameters);
        }

        public async Task GetContractByStatus(string contractStatus)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractStatus", contractStatus),
            };

            await ExecuteContractQueryAsync("selectContractByContractStatus", parameters);
        }

    }
}