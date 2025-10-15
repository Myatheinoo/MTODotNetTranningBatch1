using System;
using System.Collections.Generic;

namespace MTODotNetTrainingBatch1.MvcApiExample.DatabaseShared.Models;

public partial class TblWallet
{
    public int WalletId { get; set; }

    public string WalletName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public decimal Balance { get; set; }
}
