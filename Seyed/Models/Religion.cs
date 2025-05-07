using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Religion
{
    public int ReligionId { get; set; }

    public bool Active { get; set; }

    public string Title { get; set; } = null!;
}
