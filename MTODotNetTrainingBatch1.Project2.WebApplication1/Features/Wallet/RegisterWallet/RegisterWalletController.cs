using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.Project2.Database.Models;

namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.RegisterWallet
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWalletController : ControllerBase
    {
        // Ctrl + M,O
        //Ctrl + M,A
        private readonly AppDbContext _appDbContext;

        public RegisterWalletController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost("RegisterWallet")]
        public IActionResult RegisterWallet(RegisterWalletRequestModel requestModel)
        {
            RegisterWalletResponseModel model;

            #region Check required fields
            if (string.IsNullOrEmpty(requestModel.WalletUserName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet user name is required."  
                };
                goto result;
            }

            if (string.IsNullOrEmpty(requestModel.FullName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Full name is required."
                };
                goto result;
            }
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile no is required."
                };
                goto result;
            }
            #endregion

            #region Validate Duplicate Record
            var walletItem = _appDbContext.TblWallets.FirstOrDefault(x => x.WalletName == requestModel.WalletUserName);
            if(walletItem is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet user name is already exist."
                };
                goto result;
            }
             walletItem = _appDbContext.TblWallets.FirstOrDefault(x => x.Username == requestModel.FullName);
            if (walletItem is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Full name is already exist."
                };
                goto result;
            }
            walletItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (walletItem is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile no is already exist."
                };
                goto result;
            }
            #endregion

            #region Register Wallet

            TblWallet item = new TblWallet
            {
                Balance = 0,
                WalletName = requestModel.WalletUserName,
                Username = requestModel.FullName,
                MobileNo = requestModel.MobileNo,
            };
            _appDbContext.TblWallets.Add(item);
            _appDbContext.SaveChanges();
            #endregion

            model = new RegisterWalletResponseModel
            {
                FullName = requestModel.FullName,
                WalletUserName = requestModel.WalletUserName,
                MobileNo = requestModel.MobileNo,
                IsSuccess = true,
                Message = "Successful.",
                WalletId = item.WalletId
            };
        result:
            return Ok(model);
        }
    }

 }
