namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.RegisterWallet
{
    public class RegisterWalletResponseModel : ResponseModel
    {
        public int WalletId { get; set; }
        public string WalletUserName { get; set; }
        public string MobileNo { get; set; }
        public string FullName { get; set; }
    }

 }
