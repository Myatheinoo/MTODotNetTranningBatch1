using System;
using System.Collections.Generic;

namespace MTODotNetTrainingBatch1.Project1.Database.Models;

public partial class TblProduct
{
    public int No { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? CategoryId { get; set; }
}
