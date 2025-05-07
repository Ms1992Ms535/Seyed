using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class ClientMerge
{
    /// <summary>
    /// شناسه جدول
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// شناسه مشتری اصلی
    /// </summary>
    public int ClientIdA { get; set; }

    /// <summary>
    /// شناسه مشتری فرعی
    /// </summary>
    public int ClientIdB { get; set; }

    /// <summary>
    /// کاربر ادغام کننده
    /// </summary>
    public int? CreateBy { get; set; }

    /// <summary>
    /// تاریخ ادغام
    /// </summary>
    public DateTime? ApplyDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsMerge { get; set; }

    public bool? Active { get; set; }

    public bool? IsDone { get; set; }

    public virtual Client ClientIdANavigation { get; set; } = null!;

    public virtual ICollection<ClientMergeSystem> ClientMergeSystems { get; set; } = new List<ClientMergeSystem>();
}
