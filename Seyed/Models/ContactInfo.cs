using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class ContactInfo
{
    public long Id { get; set; }

    public long ContactId { get; set; }

    public string? Value { get; set; }

    public byte Type { get; set; }

    public string? Title { get; set; }

    public virtual Contact Contact { get; set; } = null!;
}
