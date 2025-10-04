using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MTODotNetTrainingBatch1.WinFormsApp1
{
    public class SqlService
    {
        private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Purchase",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public DataTable Query(string query,params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public int Exectue(string query,params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
