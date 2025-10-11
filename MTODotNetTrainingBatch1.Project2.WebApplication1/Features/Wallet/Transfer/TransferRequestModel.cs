namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.Transfer
{
    public class TransferRequestModel
    {
        public string FromMobileNo { get; set; } = null!;

        public string ToMobileNo { get; set; } = null!;

        public decimal Amount { get; set; }
    }
}
