using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Contact
{
    public long Id { get; set; }

    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public virtual ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
}
