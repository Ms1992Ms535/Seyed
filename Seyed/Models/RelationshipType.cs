using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class RelationshipType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public short? SortOrder { get; set; }

    public virtual ICollection<Human> Humans { get; set; } = new List<Human>();
}
