using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.Project2.Database.Models;

namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Deposite
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public DepositeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost("Deposite")]
        public IActionResult Deposite(DepositeRequestModel requestModel)
        {
            DepositeResponseModel model;
            #region Check required fields
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new DepositeResponseModel
                {
                    Message = "Mobile Number is required."
                };
                goto result;
            }

            if (requestModel.Amount <= 0)
            {
                model = new DepositeResponseModel
                {
                    Message = "Deposite amount must be greater than zero."
                };
                goto result;
            }
            #endregion

            #region validate wallet exist or not
            var walletItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if(walletItem is null)
            {
                model = new DepositeResponseModel
                {
                    Message = "This user doesn't exist."
                };
                goto result;
            }
            #endregion

            decimal oldBalance = walletItem.Balance;
            decimal newBalance = walletItem.Balance + requestModel.Amount;

            walletItem.Balance = newBalance;
            _appDbContext.SaveChanges();

            _appDbContext.TblWalletHistories.Add(new TblWalletHistory
            {
                Amount = requestModel.Amount,
                MobilNo = requestModel.MobileNo,
                TransactionType = "Deposite"
            });
            _appDbContext.SaveChanges();

            model = new DepositeResponseModel
            {
                OldBalance = oldBalance,
                NewBalance = newBalance,
                IsSuccess = true,
                Message = $"Deposite Amount - {requestModel.Amount} was successfully added."
            };
            
        result:
            return Ok(model);
        }
    }
}
