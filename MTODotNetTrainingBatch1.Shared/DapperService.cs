using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace MTODotNetTrainingBatch1.Shared;

public class DapperService : IDapperService
{
    private readonly SqlConnectionStringBuilder _connectionStringBuilder;
    public DapperService(IConfiguration configuration)
    {
        _connectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
    }
    public List<T> Query<T>(string query, object? param = null)
    {
        using IDbConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();
        var list = connection.Query<T>(query, param).ToList();
        return list;
    }

    public int Execute(string query, object? param = null)
    {
        using IDbConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();
        int result = connection.Execute(query, param);
        return result;
    }
}