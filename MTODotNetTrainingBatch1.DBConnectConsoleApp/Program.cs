// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using MTODotNetTrainingBatch1.DBConnectConsoleApp;

Console.WriteLine("Hello, World!");
//SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder()
//connectionStringBuilder.DataSource = ".";
//connectionStringBuilder.InitialCatalog = "Purchase";
//connectionStringBuilder.UserID = "sa";
//connectionStringBuilder.Password = "sasa@123";
//connectionStringBuilder.TrustServerCertificate = true;

ProductService purchaseService = new ProductService();
//purchaseService.Read();
//purchaseService.Create();
//purchaseService.Update();
//purchaseService.Delete();
//purchaseService.Login();
//purchaseService.Detail(1);
LoginDapperService loginDapperService = new LoginDapperService();
loginDapperService.Read();
Console.ReadLine();