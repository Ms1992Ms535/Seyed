using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class BlackList
{
    /// <summary>
    /// شناسه جدول
    /// </summary>
    public int BlackListId { get; set; }

    /// <summary>
    /// کلید خارجی از جدول Client
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// تاریخ اضافه کردن به لیست سیاه
    /// </summary>
    public DateTime? AddDate { get; set; }

    /// <summary>
    /// تاریخ حذف از لیست سیاه
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    public string? Comment { get; set; }

    /// <summary>
    /// وضعیت:1:فعال در لیست سیاه 0 حذف شده از لیست سیاه
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// کلید خارجی از جدول CustomerStatusReason
    /// </summary>
    public string? ReasonIds { get; set; }

    /// <summary>
    /// کاربر اضافه کننده به لیست سیاه
    /// </summary>
    public int? AddUserId { get; set; }

    /// <summary>
    /// کاربر حذف کننده از لیست سیاه
    /// </summary>
    public int? DeleteUserId { get; set; }

    /// <summary>
    /// شعبه اضافه کننده به لیست سیاه
    /// </summary>
    public int? AddBranchId { get; set; }

    /// <summary>
    /// شعبه حذف کننده از لیست سیاه
    /// </summary>
    public int? DeleteBranchId { get; set; }

    public long? OriginalBranchId { get; set; }

    public long? OriginalId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
