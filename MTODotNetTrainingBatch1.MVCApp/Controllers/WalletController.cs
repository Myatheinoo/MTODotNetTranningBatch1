using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MTODotNetTrainingBatch1.MVCApp.Controllers
{
    public class WalletController : Controller
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        [ActionName("Index")]
        public async Task<IActionResult> IndexAsync()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var list = await db.QueryAsync<WalletModel>("select * from tbl_wallet");

            return View("WalletIndex",list);
        }

        [ActionName("Create")]
        public IActionResult CreateWallet()
        {
            return View("CreateWallet");
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateWalletAsync(WalletModel requestModel)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Wallet]
           ([WalletName]
           ,[Username]
           ,[MobileNo]
           ,[Balance])
     VALUES
           (@WalletName
           ,@Username
           ,@MobileNo
           ,@Balance)";

            var result = await db.ExecuteAsync(query, requestModel);

            bool isSuccess = result > 0;
            string message = result > 0 ? "Success" : "Fail";

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> EditWalletAsync(int id)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"
SELECT [WalletId]
      ,[WalletName]
      ,[Username]
      ,[MobileNo]
      ,[Balance]
  FROM [dbo].[Tbl_Wallet]
WHERE WalletId = @WalletId";

            var model = await db.QueryFirstOrDefaultAsync<WalletModel>(query, new
            {
                WalletId = id
            });
            if(model is null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "Not found.";
                return RedirectToAction("Index");
            }
            return View("EditWallet",model);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateWallet(int id, WalletModel requestModel)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();

            requestModel.WalletId = id; 

            string query = @"
UPDATE [dbo].[Tbl_Wallet]
   SET [WalletName] = @WalletName
      ,[Username] = @Username
      ,[MobileNo] = @MobileNo
      ,[Balance] = @Balance
 WHERE WalletId=@WalletId";

           var result = await db.ExecuteAsync(query, requestModel);

            bool isSuccess = result > 0;
            string message = result > 0 ? "Success" : "Fail";

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteWalletAsync(int id)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"
SELECT [WalletId]
      ,[WalletName]
      ,[Username]
      ,[MobileNo]
      ,[Balance]
  FROM [dbo].[Tbl_Wallet]
WHERE WalletId = @WalletId";

            //var model = await db.QueryFirstOrDefaultAsync<WalletModel>(query, new
            //{
            //    WalletId = id
            //});
            //if (model is null)
            //{
            //    TempData["IsSuccess"] = false;
            //    TempData["Message"] = "Not found.";
            //    return RedirectToAction("Index");
            //}
            return View("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();

            string query = @"
DELETE FROM [dbo].[Tbl_Wallet]
      WHERE WalletId=@WalletId";

            var result =await db.ExecuteAsync(query,new {WalletId= id});

            bool isSuccess = result > 0;
            string message = result > 0 ? "Success" : "Fail";

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("Index");
        }
    }

    public class WalletModel
    {
        public int WalletId {  get; set; }
        public string WalletName { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }    
        public decimal Balance {  get; set; }
    }
}
