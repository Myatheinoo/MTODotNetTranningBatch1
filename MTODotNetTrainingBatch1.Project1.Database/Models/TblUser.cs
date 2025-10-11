using System;
using System.Collections.Generic;

namespace MTODotNetTrainingBatch1.Project1.Database.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
