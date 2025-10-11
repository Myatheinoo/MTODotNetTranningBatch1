using System;
using System.Collections.Generic;

namespace MTODotNetTrainingBatch1.DbShared.Models;

public partial class TblPurchase
{
    public int PurchaseId { get; set; }

    public string? InvoiceNo { get; set; }

    public DateOnly? Date { get; set; }

    public int? Code { get; set; }

    public string? Description { get; set; }

    public int? Qty { get; set; }

    public decimal? Price { get; set; }

    public decimal? TotalAmount { get; set; }
}
