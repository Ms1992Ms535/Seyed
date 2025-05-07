using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class CreditWorthiness
{
    /// <summary>
    /// شناسه
    /// </summary>
    public int CreditWorthinessId { get; set; }

    /// <summary>
    /// کلید خارجی از جدول client
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// تاریخ اضافه شدن به لیست خوش حسابان
    /// </summary>
    public DateTime? AddDate { get; set; }

    /// <summary>
    /// تاریخ حذف از لیست خوش حسابان
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// وضعیت 1: فعال در لیست خوش حسابی، 0 حذف شده از لیست خوش حسابی
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// کلید خارجی دلیل حذف یا اضافه از این جدول(CustomerstatusReason)
    /// </summary>
    public string? ReasonIds { get; set; }

    public string? Comment { get; set; }

    /// <summary>
    /// کاربر اضافه کننده به لیست خوش حسابان
    /// </summary>
    public int? AddUserId { get; set; }

    /// <summary>
    /// کاربر حذف کننده از لیست خوش حسابان
    /// </summary>
    public int? DeleteUserId { get; set; }

    /// <summary>
    /// شعبه اضافه کننده به لیست خوش حسابان
    /// </summary>
    public int? AddBranchId { get; set; }

    /// <summary>
    /// شعبه حذف کننده از لیست خوش حسابان
    /// </summary>
    public int? DeleteBranchId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
