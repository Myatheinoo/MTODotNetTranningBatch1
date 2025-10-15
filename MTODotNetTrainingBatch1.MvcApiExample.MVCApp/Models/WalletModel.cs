namespace MTODotNetTrainingBatch1.MvcApiExample.MVCApp.Models
{
    public partial class WalletModel
    {
        public int WalletId { get; set; }

        public string WalletName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public decimal Balance { get; set; }
    }

}
