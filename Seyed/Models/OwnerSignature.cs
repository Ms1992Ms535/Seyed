using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class OwnerSignature
{
    /// <summary>
    /// شناسه جدول
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// شناسه مشتری حقوقی
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// شناسه صاحب امضا حقیقی از جدولclient
    /// </summary>
    public int OwnerSignatureClientId { get; set; }

    /// <summary>
    /// تاریخ انقضاء امضاء
    /// </summary>
    public DateTime? ExpireDateSignature { get; set; }

    public bool? Active { get; set; }

    public virtual Client Client { get; set; } = null!;
}
