using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Lab04.Data;

public static class DbConnectionFactory
{
    public static SqlConnection CreateConnection()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["NeptunoDB"].ConnectionString;
        return new SqlConnection(connectionString);
    }
}
