namespace MTODotNetTrainingBatch1.Project2.WebApplication1.Features.Wallet.CheckBalance
{
    internal class CheckBalanceResponseModel : ResponseModel
    {
        public decimal Balance { get; set; }
        public List<CheckBalanceTransactionHistoryModel> checkBalanceTransactionHistoryModels { get; set; }
    }
    public class CheckBalanceTransactionHistoryModel
    {
        public string TransactionNo { get; set; }
        public string FromMobileNo { get; set; }
        public string ToMobileNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
