using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MTODotNetTrainingBatch1.MVCApp2.Controllers
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
        public IActionResult WalletIndex()
        {
            return View("WalletIndex");
        }
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> WalletListAsync()
        {
            try
            {
                using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();

                var list = await db.QueryAsync<WalletModel>("select * from tbl_wallet order by WalletId desc");
                return Json(new { Message = "Successful.", IsSuccess = true, Data = list });
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.ToString(), IsSuccess = false });
            }
            
        }

        [ActionName("Create")]
        public IActionResult CreateWallet()
        {
            return View("CreateIndex");
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> CreateWalletAsync(WalletModel requestModel)
        {
            try
            {
                using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();
                if (!string.IsNullOrEmpty(requestModel.WalletName))
                {
                    requestModel.WalletName = requestModel.WalletName.Trim();   
                }

                string query = @"
                                INSERT INTO [dbo].[Tbl_Wallet]
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

                return Json(new { Message = result > 0 ? "Successful." : "Fali.", IsSuccess = result > 0 });
            }
            catch(Exception ex)
            {
                return Json(new { Message = ex.ToString(), IsSuccess = false });

            }
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

            return View("EditIndex", model);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateWallet(WalletModel requestModel)
        {
            try
            {
                using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();
  
                string query = @"
                                UPDATE [dbo].[Tbl_Wallet]
                                   SET [WalletName] = @WalletName
                                      ,[Username] = @Username
                                      ,[MobileNo] = @MobileNo
                                      ,[Balance] = @Balance
                                 WHERE WalletId=@WalletId";

                var result = await db.ExecuteAsync(query, requestModel);

                return Json(new { Message = result>0 ? "Successful." : "Fali.", IsSuccess = result > 0 });
            }
            catch(Exception ex)
            {
                return Json(new { Message =ex.ToString(), IsSuccess = false });
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteWallet(WalletModel requestModel)
        {
            try
            {
                using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();

                string query = @"
                                DELETE FROM [dbo].[Tbl_Wallet]
                                      WHERE WalletId=@WalletId";

                var result = await db.ExecuteAsync(query, requestModel);
                return Json(new { Message = result > 0 ? "Successful." : "Fali.", IsSuccess = result > 0 });
            }
            catch(Exception ex)
            {
                return Json(new { Message = ex.ToString(), IsSuccess = false });
            }
           
        }
    }
    public class WalletModel
    {
        public int WalletId { get; set; }
        public string WalletName { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public decimal Balance { get; set; }
    }
}
