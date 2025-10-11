using System.Data;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace MTODotNetTrainingBatch1.Shared;

public class AdoDotNetService
{
    private readonly SqlConnectionStringBuilder _connectionStringBuilder;

    public AdoDotNetService(string connectionStringBuilder)
    {
        _connectionStringBuilder = new SqlConnectionStringBuilder(connectionStringBuilder);
    }

    public DataTable Query(string query, params SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapter.Fill(dt);

        connection.Close();

        return dt;
    }

    public int Execute(string query, params SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        return result;
    }

    public List<T> QueryV2 <T>(string query, params SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapter.Fill(dt);

        connection.Close();

        string jsonString = JsonConvert.SerializeObject(dt);
        var list = JsonConvert.DeserializeObject<List<T>>(jsonString);

        return list;
    }
}
