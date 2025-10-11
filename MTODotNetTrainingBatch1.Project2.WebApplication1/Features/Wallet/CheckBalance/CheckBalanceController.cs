using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.Project2.Database.Models;
using MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.RegisterWallet;
using MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Withdraw;

namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.CheckBalance
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckBalanceController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CheckBalanceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost("CheckBalance")]
        public IActionResult CheckBalance(CheckBalanceRequestModel requestModel)
        {
            CheckBalanceResponseModel model;
            if (string.IsNullOrEmpty(requestModel.MobilNo))
            {
                model = new CheckBalanceResponseModel
                {
                    Message = "Mobile number is required."
                };
                goto result;
            }
            var walletItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobilNo);
            if (walletItem is null)
            {
                model = new CheckBalanceResponseModel
                {
                    Message = "This mobile doesn't exist."
                };
                goto result;
            }
            var list = _appDbContext.TblTransactions.Where(x =>
                    x.FromMobileNo == requestModel.MobilNo ||
                    x.ToMobileNo == requestModel.MobilNo
                    )
                    .OrderByDescending(x => x.TransactionDate)
                    .Take(5)
                    .ToList();
            var transactionHistoryList = list.Select(x => new CheckBalanceTransactionHistoryModel
            {
                TransactionDate = x.TransactionDate,
                TransactionNo = x.TransferNo,
                FromMobileNo = x.FromMobileNo,
                ToMobileNo = x.ToMobileNo,
                Amount = x.Amount,
            }).ToList();

            model = new CheckBalanceResponseModel
            {
                Balance = walletItem.Balance,
                IsSuccess = true,
                Message = "Successful.",
                checkBalanceTransactionHistoryModels = transactionHistoryList
            };

        result:
            return Ok(model);
        }
    }
}
