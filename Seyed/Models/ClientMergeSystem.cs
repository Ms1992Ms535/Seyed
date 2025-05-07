using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class ClientMergeSystem
{
    public int Id { get; set; }

    /// <summary>
    /// کلید خارجی از جدولClientMerge
    /// </summary>
    public int MergeId { get; set; }

    public int? SystemType { get; set; }

    public string EntityName { get; set; } = null!;

    public int EntityId { get; set; }

    public virtual ClientMerge Merge { get; set; } = null!;
}
