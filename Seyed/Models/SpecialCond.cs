using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class SpecialCond
{
    public byte Id { get; set; }

    public string Title { get; set; } = null!;

    public bool Active { get; set; }

    public byte? SortOrder { get; set; }
}
