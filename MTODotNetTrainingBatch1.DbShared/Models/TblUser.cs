using System;
using System.Collections.Generic;

namespace MTODotNetTrainingBatch1.DbShared.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
