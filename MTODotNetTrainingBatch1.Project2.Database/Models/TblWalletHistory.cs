using System;
using System.Collections.Generic;

namespace MTODotNetTrainingBatch1.Project2.Database.Models;

public partial class TblWalletHistory
{
    public int WalletHistoryId { get; set; }

    public string MobilNo { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }
}
