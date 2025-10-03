using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace MTODotNetTrainingBatch1.DBConnectConsoleApp
{
    internal class LoginDapperService
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Purchase",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        
       public void Read()
        {
            string query = "select * from tbl_user";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString); 
            var lst = db.Query<User>(query).ToList();

            foreach (var item in lst)
            {
                Console.WriteLine(item.No);
                Console.WriteLine(item.Username);
                Console.WriteLine(item.Password);
            }
        }

        public class User
        {
            public int No { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
