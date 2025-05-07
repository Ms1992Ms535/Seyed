using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class RegSeri
{
    public byte Id { get; set; }

    public string Seri { get; set; } = null!;

    public byte SortOrder { get; set; }
}
