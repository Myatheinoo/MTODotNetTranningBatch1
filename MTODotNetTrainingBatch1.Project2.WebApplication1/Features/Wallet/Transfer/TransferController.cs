using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.Project2.Database.Models;
using MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Withdraw;

namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly decimal _miniamount;
        private readonly IConfiguration _configuration;
        public TransferController(AppDbContext appDbContext,IConfiguration configuration)
            {  
                _appDbContext = appDbContext;
                _configuration = configuration;
                _miniamount = Convert.ToDecimal(_configuration.GetSection("MinAmount").Value);
            }
        [HttpPost("Transfer")]
        public IActionResult Transfer(TransferRequestModel requestModel)
        {
            TransferResponseModel model;

            #region Check required fields
            if (string.IsNullOrEmpty(requestModel.FromMobileNo))
            {
                model = new TransferResponseModel
                {
                    Message = "From mobile number is required."
                };
                goto Results;
            }

            if (string.IsNullOrEmpty(requestModel.ToMobileNo))
            {
                model = new TransferResponseModel
                {
                    Message = "To mobile number is required."
                };
                goto Results;
            }

            if (requestModel.Amount <= 0)
            {
                model = new TransferResponseModel
                {
                    Message = "Amount must be greater than zero."
                };
                goto Results;
            }

            #endregion

            var fromMobileItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.FromMobileNo);
            if(fromMobileItem is null)
            {
                model = new TransferResponseModel
                {
                    Message = "This mobile doesn't exist."
                };
                goto Results;
            }

            var toMobileItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.ToMobileNo);
            if (toMobileItem is null)
            {
                model = new TransferResponseModel
                {
                    Message = "This mobile doesn't exist."
                };
                goto Results;
            }

            if(requestModel.Amount > fromMobileItem.Balance - _miniamount)
            {
                model = new TransferResponseModel
                {
                    Message = "Insufficient balance."
                };
                goto Results;
            }

            fromMobileItem.Balance -= requestModel.Amount;
            toMobileItem.Balance += requestModel.Amount;
            _appDbContext.SaveChanges();

            _appDbContext.TblTransactions.Add(new TblTransaction
            {
                FromMobileNo = requestModel.FromMobileNo,
                ToMobileNo = requestModel.ToMobileNo,
                Amount = requestModel.Amount,
                TransactionDate = DateTime.UtcNow,
                TransferNo = DateTime.Now.ToString("yyyyMMdd_hhmmss_fff"),
                TransactionId = Ulid.NewUlid().ToString()
            });
            _appDbContext.SaveChanges();

            model = new TransferResponseModel()
            {
                IsSuccess = true,
                Message = "Transfer is successful."
            };

        Results:
            return Ok(model);
        }
    }
}
