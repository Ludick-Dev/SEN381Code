using CallCenter.Database;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CallCenter.src.dataAccess
{
    public class ClientDataAccess
    {
        //display list of all clients
        public List<Client> DisplayAllClients()
        {  
            DBconnect conn = new DBconnect();
            List <Client> clients = new List<Client> ();
            SqlConnection sqlConnection = new SqlConnection (conn.connectionString);
            SqlCommand sqlCommand = new SqlCommand("selectClientInfo", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = new Client();

                        client.clientId = reader.GetGuid(0);
                        client.clientName = reader.GetString(1);
                        client.phoneNumber = reader.GetString(2);
                        client.clientType = (ClientTypes)Enum.Parse(typeof(ClientTypes), reader.GetString(3));
                        string dbContracts = reader.GetString(4);

                        foreach (string contract in dbContracts.Split(','))
                        {
                            ContractType contractType = (ContractType)Enum.Parse(typeof(ContractType), contract.Trim());
                            Contract cont = new Contract();
                            cont.contractType = contractType;
                            client.contracts.Add(cont);
                        }

                        clients.Add(client);
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
                sqlConnection.Close();
            }

            return clients;
        }

        //display client's details via client ID
        public Client DisplayClientDetails(int clientId)
        {
            DBconnect conn = new DBconnect();
            SqlConnection sqlConnection = new SqlConnection(conn.connectionString);
            SqlCommand cmd = new SqlCommand("selectClientDetails", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientId", clientId);
            Client client = new Client();

            try
            {
                sqlConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client.clientId = reader.GetGuid(0);
                        client.clientName = reader.GetString(1);
                        client.phoneNumber = reader.GetString(2);
                        client.clientAddress = reader.GetString(3);
                        client.lastCallDate = reader.GetDateTime(4);
                        client.requestId = reader.GetInt32(5);
                        client.employeeId = reader.GetInt32(6);
                        client.clientNotes = reader.GetString(7);
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
                sqlConnection.Close();
            }

            return client;
        }

        //search client via client ID
        public Client SearchClient(int clientId)
        {
            DBconnect conn = new DBconnect();
            SqlConnection sqlConnection = new SqlConnection(conn.connectionString);
            SqlCommand cmd = new SqlCommand("searchClientDetails", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientId", clientId);
            Client client = new Client();

            try
            {
                sqlConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client.clientId = reader.GetGuid(0);
                        client.clientName = reader.GetString(1);
                        client.phoneNumber = reader.GetString(2);
                        client.clientType = (ClientTypes)Enum.Parse(typeof(ClientTypes), reader.GetString(3));
                        string dbContracts = reader.GetString(4);

                        foreach (string contract in dbContracts.Split(','))
                        {
                            ContractType contractType = (ContractType)Enum.Parse(typeof(ContractType), contract.Trim());
                            Contract cont = new Contract();
                            cont.contractType = contractType;
                            client.contracts.Add(cont);
                        }
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
                sqlConnection.Close();
            }

            return client;
        }
    }
}
