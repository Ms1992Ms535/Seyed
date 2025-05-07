using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Company
{
    /// <summary>
    /// شناسه
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// تاریخ ثبت
    /// </summary>
    public DateTime? CreateDate { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// شماره ثبت
    /// </summary>
    public string? RegNo { get; set; }

    /// <summary>
    /// محل ثبت
    /// </summary>
    public string? RegPlace { get; set; }

    /// <summary>
    /// تاریخ ثبت
    /// </summary>
    public DateTime? RegDate { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// شماره نامه
    /// </summary>
    public string? LetterNo { get; set; }

    /// <summary>
    /// نام رابط حساب
    /// </summary>
    public string? RelationPerson { get; set; }

    /// <summary>
    /// تاریخ معرفی رابط
    /// </summary>
    public DateTime? RelationPersonDate { get; set; }

    /// <summary>
    /// مدیر عامل
    /// </summary>
    public string? Boss { get; set; }

    public string? Email { get; set; }

    /// <summary>
    /// واحد
    /// </summary>
    public string? PartName { get; set; }

    /// <summary>
    /// مسئول
    /// </summary>
    public string? PartMaster { get; set; }

    public string? Mobile { get; set; }

    public byte[] TimeStamp { get; set; } = null!;

    public string? NationalNo { get; set; }

    /// <summary>
    /// مهر دارد یا خیر
    /// </summary>
    public bool? Stamp { get; set; }

    /// <summary>
    /// کد اقتصادی
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// نام به لاتین
    /// </summary>
    public string? LatinCompanyName { get; set; }

    /// <summary>
    /// کاربر ثبت کننده مشتری
    /// </summary>
    public int? UserId { get; set; }

    public long? OriginalId { get; set; }

    public long? OriginalBranchId { get; set; }

    public DateTime? ModifyDate { get; set; }

    /// <summary>
    /// 1 تأسیس شده
    /// 2 در حال تأسیس
    /// 3 نهاد
    /// </summary>
    public byte? CompanyType { get; set; }

    public bool? IsMobileVerified { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
