using System.Data;
using Microsoft.Data.SqlClient;

public class DatabaseServices
{
    private readonly string _connectionString;

    public DatabaseServices(IConfiguration configuration)
    {
        _connectionString = configuration.GetSection("Database:DefaultConnection").Value;
    }

    public IDbConnection GetOpenConnection()
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public IDbCommand CreateCommand(string query, IDbConnection connection)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = query;
        return command;
    }

    public void CloseConnection(IDbConnection connection)
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
}
