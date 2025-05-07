using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class HumanCategory
{
    public byte Id { get; set; }

    public string Title { get; set; } = null!;

    public bool Active { get; set; }

    public byte? SortOrder { get; set; }

    public virtual ICollection<Human> Humans { get; set; } = new List<Human>();
}
