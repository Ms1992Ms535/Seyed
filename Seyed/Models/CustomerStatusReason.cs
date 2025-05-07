using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class CustomerStatusReason
{
    /// <summary>
    /// شناسه
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 0=CreditWorthiness   1=BlackList
    /// </summary>
    public bool Type { get; set; }

    /// <summary>
    /// 0:delete Reason,           1: add reason
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// عنوان دلیل
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// فعال بودن
    /// </summary>
    public bool Active { get; set; }

    public byte? SortOrder { get; set; }
}
