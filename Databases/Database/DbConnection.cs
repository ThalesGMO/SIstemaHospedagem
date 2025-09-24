using system.data.sqlclient;

using System.Data.SqlClient;

public class Db
{
    private readonly string _connectionString;

    public Db(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection GetConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return conn;
    }
}