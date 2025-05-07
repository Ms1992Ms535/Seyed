using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Human
{
    /// <summary>
    /// شناسه
    /// </summary>
    public int HumanId { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    public string? HumanName { get; set; }

    /// <summary>
    /// فامیل
    /// </summary>
    public string? Family { get; set; }

    /// <summary>
    /// نام پدر
    /// </summary>
    public string? FatherName { get; set; }

    /// <summary>
    /// شماره شناسنامه
    /// </summary>
    public string? RegNo { get; set; }

    /// <summary>
    /// کد ملی
    /// </summary>
    public string? NationalNo { get; set; }

    /// <summary>
    /// محل ثبت
    /// </summary>
    public string? RegPlace { get; set; }

    /// <summary>
    /// شغل
    /// </summary>
    public string? Job { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    public bool Sex { get; set; }

    public string? Comment { get; set; }

    /// <summary>
    /// تاریخ ثبت
    /// </summary>
    public DateTime? CreateDate { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    /// <summary>
    /// شماره سریال
    /// </summary>
    public string? RegSerial { get; set; }

    /// <summary>
    /// محل تولد
    /// </summary>
    public string? BirthPlace { get; set; }

    public byte[] TimeStamp { get; set; } = null!;

    /// <summary>
    /// نام به لاتین
    /// </summary>
    public string? LatinName { get; set; }

    /// <summary>
    /// فامیل به لاتین
    /// </summary>
    public string? LatinFamily { get; set; }

    /// <summary>
    /// ملیت
    /// </summary>
    public int? NationalId { get; set; }

    /// <summary>
    /// کاربر ثبت کننده مشتری
    /// </summary>
    public int? UserId { get; set; }

    public long? OriginalId { get; set; }

    public long? OriginalBranchId { get; set; }

    /// <summary>
    ///  تحصیلات کلاسیک
    /// </summary>
    public int? EducationId { get; set; }

    /// <summary>
    /// مجرد یا متاهل
    /// </summary>
    public bool? Marriage { get; set; }

    /// <summary>
    /// شناسه مذهب
    /// </summary>
    public int? ReligionId { get; set; }

    /// <summary>
    /// شهرت
    /// </summary>
    public string? NickName { get; set; }

    /// <summary>
    /// شناسه شرایط خاص
    /// </summary>
    public byte? SpecialCondId { get; set; }

    /// <summary>
    /// تصویر دارد یا خیر
    /// </summary>
    public bool? Pic { get; set; }

    /// <summary>
    /// اثر انگشت دارد یا خیر
    /// </summary>
    public bool? Finger { get; set; }

    public DateTime? ModifyDate { get; set; }

    public byte? CategoryId { get; set; }

    /// <summary>
    /// کد کامپیوتری طلبه
    /// </summary>
    public string? CategoryCode { get; set; }

    public int? RelationshipTypeId { get; set; }

    public int? RelationshipClientId { get; set; }

    public bool? IsMobileVerified { get; set; }

    public string? Stime { get; set; }

    public string? DatCont { get; set; }

    public int? RowNum { get; set; }

    public string? NameOld { get; set; }

    public string? FamilyOld { get; set; }

    public string? FathernameOld { get; set; }

    public string? RegnoOld { get; set; }

    public long? MirEmadHumanId { get; set; }

    public virtual HumanCategory? Category { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual RelationshipType? RelationshipType { get; set; }
  //  public virtual Client? Client { get; set; }

}
