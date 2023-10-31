using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class TechnicianRepository
    {
        private readonly DatabaseServices _dbService;

        public TechnicianRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Technician>> ExecuteTechnicianQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Technician> technicians = new List<Technician>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Technician technician = new Technician
                            {
                                technicianId = reader.GetGuid(reader.GetOrdinal("technicianId")),
                                employeeId = reader.GetGuid(reader.GetOrdinal("employeeId")),
                                skillLevel = reader.GetInt32(reader.GetOrdinal("skillLevel")),
                                availability = reader.GetBoolean(reader.GetOrdinal("availability")),
                                serviceArea = reader.GetString(reader.GetOrdinal("serviceArea")),
                                certificationLevel = reader.GetString(reader.GetOrdinal("certificationLevel")),
                            };
                            technicians.Add(technician);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return technicians;
            }
        }

        public async Task AddTechnician(Technician technician)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@technicianId", technician.technicianId),
                new SqlParameter("@employeeId", technician.employeeId),
                new SqlParameter("@skillLevel", technician.skillLevel),
                new SqlParameter("@availability", technician.availability),
                new SqlParameter("@serviceArea", technician.serviceArea),
                new SqlParameter("@certificationLevel", technician.certificationLevel),
            };

            await ExecuteTechnicianQueryAsync("addTechnician", parameters);
        }

        public async Task UpdateTechnician(Technician technician)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@technicianId", technician.technicianId),
                new SqlParameter("@employeeId", technician.employeeId),
                new SqlParameter("@skillLevel", technician.skillLevel),
                new SqlParameter("@availability", technician.availability),
                new SqlParameter("@serviceArea", technician.serviceArea),
                new SqlParameter("@certificationLevel", technician.certificationLevel),
            };

            await ExecuteTechnicianQueryAsync("updateTechnician", parameters);
        }

        public async Task<List<Technician>> GetAllTechnicians()
        {
            return await ExecuteTechnicianQueryAsync("selectAllTechnicians");
        }

        public async Task GetTechnicianById(Guid technicianId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@technicianId", technicianId),
            };

            await ExecuteTechnicianQueryAsync("selectTechnicianById", parameters);
        }

        public async Task GetTechnicianByEmployeeId(Guid employeeId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", employeeId),
            };

            await ExecuteTechnicianQueryAsync("selectTechnicianByEmployeeId", parameters);
        }

        public async Task GetTechnicianBySkillLevel(int skillLevel)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@skillLevel", skillLevel),
            };

            await ExecuteTechnicianQueryAsync("selectTechnicianBySkillLevel", parameters);
        }

        public async Task GetTechnicianByServiceArea(string serviceArea)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@serviceArea", serviceArea),
            };

            await ExecuteTechnicianQueryAsync("selectTechnicianByServiceArea", parameters);
        }

        public async Task GetTechnicianByAvailability(string availability)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@availability", availability),
            };

            await ExecuteTechnicianQueryAsync("selectTechnicianByAvailability", parameters);
        }

        public async Task GetTechnicianBycertificationLevel(string certificationLevel)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@certificationLevel", certificationLevel),
            };

            await ExecuteTechnicianQueryAsync("selectTechnicianByCertificationLevel", parameters);
        }

    }
}