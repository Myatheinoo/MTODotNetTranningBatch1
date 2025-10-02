using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace MTODotNetTrainingBatch1.DBConnectConsoleApp
{
    internal class ProductService
    {
        // database connection
        //SqlConnection connection = new SqlConnection("Data Source = localhost; Initial Catalog = Purchase;User ID = sa;Password = sasa@123;TrustServerCertificate=True;Encrypt=false;");
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
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Purchase";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Console.WriteLine(dr["PurchaseID"]);
                Console.WriteLine(dr["Code"]);
                Console.WriteLine(dr["Description"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine("_______________________");
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["PurchaseID"]);
                Console.WriteLine(dr["Code"]);
                Console.WriteLine(dr["Description"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine("_______________________");
            }
        }
        public void Detail(int purchaseid)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Purchase where PurchaseID = {purchaseid}";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Console.WriteLine(dr["PurchaseID"]);
                Console.WriteLine(dr["Code"]);
                Console.WriteLine(dr["Description"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine("_______________________");
            }
            else
            {
                Console.WriteLine("No record found");
                return;
            }
        }
        public void Create()
        {
            Console.Write("Enter product name : ");
            string name = Console.ReadLine()!;

            Console.Write("Enter product code : ");
            string code = Console.ReadLine()!;

            BeforePrice:
            Console.Write("Enter product price : ");
            string pirceResult = Console.ReadLine()!;
            bool isdecimal = decimal.TryParse(pirceResult, out decimal price);
            if(!isdecimal)
            {
                Console.WriteLine("Enter valid price");
                goto BeforePrice;
            }

            BeforeQuantity:
            Console.Write("Enter product qunatity : ");
            string quantityResult = Console.ReadLine()!;
            bool isInt = int.TryParse(quantityResult, out int quantity);
            if(!isInt)
            {
                Console.WriteLine("Enter valid quantity.");
                goto BeforeQuantity;
            }

            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            string qurey = $@"
INSERT INTO[dbo].[Tbl_Product]
           ([Name]
           , [Code]
           , [Price]
           , [Quantity])
     VALUES
           (@Name
           ,@Code
           ,@Price
           ,@Quantity)";

            SqlCommand cmd = new SqlCommand(qurey, connection);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Code",code);
            cmd.Parameters.AddWithValue("@Price",price);
            cmd.Parameters.AddWithValue("@Quantity", quantity);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Create product is successful.");

            connection.Close() ;
        }
        public void Update()
        {
            BeforeInputId:
            Console.Write("Enter product id: ");
            string idResult = Console.ReadLine()!;
            bool isInt = int.TryParse(idResult, out int id);
            if (!isInt)
            {
                Console.WriteLine("Product id not found.");
                goto BeforeInputId;
            }

            Console.Write("Enter product name : ");
            string name = Console.ReadLine()!;

            Console.Write("Enter product code : ");
            string code = Console.ReadLine()!;

        BeforePrice:
            Console.Write("Enter product price : ");
            string pirceResult = Console.ReadLine()!;
            bool isdecimal = decimal.TryParse(pirceResult, out decimal price);
            if (!isdecimal)
            {
                Console.WriteLine("Enter valid price");
                goto BeforePrice;
            }

        BeforeQuantity:
            Console.Write("Enter product qunatity : ");
            string quantityResult = Console.ReadLine()!;
            bool isQuantityInt = int.TryParse(quantityResult, out int quantity);
            if (!isQuantityInt)
            {
                Console.WriteLine("Enter valid quantity.");
                goto BeforeQuantity;
            }

            string query = $@"
UPDATE [dbo].[Tbl_Product]
   SET [Name] = @Name
      ,[Code] = @Code
      ,[Price] = @Price
      ,[Quantity] = @Quantity
 WHERE No = @Id";
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Code", code);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Quantity", quantity);

            var result = cmd.ExecuteNonQuery();

            Console.WriteLine("Update successful.");

            connection.Close();
        }
        public void Delete()
        {
        BeforeInputId:
            Console.Write("Enter product id: ");
            string idResult = Console.ReadLine()!;
            bool isInt = int.TryParse(idResult, out int id);
            if (!isInt)
            {
                Console.WriteLine("Product id not found.");
                goto BeforeInputId;
            }

            string query = $@"
DELETE FROM [dbo].[Tbl_Product]
      WHERE No=@Id";

            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            var result = cmd.ExecuteNonQuery();

            Console.WriteLine("Delete successful.");

            connection.Close();
        }
        public void Login()
        {
            Console.Write("Enter user name: ");
            string username = Console.ReadLine()!;
            
            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection( _connectionStringBuilder.ConnectionString); 
            connection.Open();

            string query = $"SP_Login";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("login is successful.");
            connection.Close();
        }
    }
}
