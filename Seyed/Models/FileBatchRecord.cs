using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class FileBatchRecord
{
    public int Id { get; set; }

    public int? FileBatchId { get; set; }

    public string Record { get; set; } = null!;

    public string? ResultMsg { get; set; }

    public string? Result { get; set; }
}
