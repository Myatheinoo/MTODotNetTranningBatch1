namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Withdraw
{
    public class WithdrawResponseModel : ResponseModel
    {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
}
