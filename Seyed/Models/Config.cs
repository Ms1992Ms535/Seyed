using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Config
{
    public string Key { get; set; } = null!;

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    public string? Comment { get; set; }
}
