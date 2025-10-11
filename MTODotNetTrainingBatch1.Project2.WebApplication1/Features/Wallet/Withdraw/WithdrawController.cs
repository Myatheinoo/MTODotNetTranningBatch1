using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.Project2.Database.Models;

namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Withdraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    { 
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly decimal _miniamount;
        public WithdrawController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _miniamount =Convert.ToDecimal( _configuration.GetSection("MinAmount").Value);
        }

        [HttpPost("Withdraw")]
        public IActionResult Withdraw(WithdrawRequestModel requestModel)
        {
            WithdrawResponseModel model;
            
            #region Check required fields
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new WithdrawResponseModel
                {
                    Message = "Mobile number is required."
                };
                goto result;
            }

            if (requestModel.Amount <= 0)
            {
                model = new WithdrawResponseModel
                {
                    Message = "Withdraw amount must be greater than zero."
                };
                goto result;
            }
            
            #endregion

            #region validate wallet account exist or not
            var walletItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if(walletItem is null)
            {
                model = new WithdrawResponseModel
                {
                    Message = "This mobile doesn't exist."
                };
                goto result;
            }
            
            #endregion

            decimal oldBalance = walletItem.Balance;
            
            if (requestModel.Amount > walletItem.Balance - _miniamount)
            {
                model = new WithdrawResponseModel
                {
                    OldBalance = oldBalance,
                    NewBalance = oldBalance,
                    Message = $"Insufficient amount.Minimun amount must be 10000."
                };
                goto result;
            }

            decimal newBalance = walletItem.Balance - requestModel.Amount;

            walletItem.Balance = newBalance;
            _appDbContext.SaveChanges();

            _appDbContext.TblWalletHistories.Add(new TblWalletHistory
            {
                Amount = requestModel.Amount,
                MobilNo = requestModel.MobileNo,
                TransactionType = "Withdraw"
            });
            _appDbContext.SaveChanges();

            model = new WithdrawResponseModel
            {
                OldBalance = oldBalance,
                NewBalance = newBalance,
                IsSuccess = true,
                Message = $"Withdraw amount - {requestModel.Amount} was successful withdraw."
            };

        result:
            return Ok(model);
        }
    }
}
