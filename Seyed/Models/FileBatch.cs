using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class FileBatch
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    /// <summary>
    /// تعداد سطرهای فایل
    /// </summary>
    public int RecordCount { get; set; }

    /// <summary>
    /// 0  ثبت دسته‏ای مشتری
    /// 1  ادغام 
    /// 2 برگشت ادغام
    /// 3 فایل اطلاعات مشتری جهت یافتن مشتریان مشابه
    /// --
    /// ادغام و برگشت ادغام بصورت فایل نیست و در اینجا کاربرد ندارد
    /// </summary>
    public byte Type { get; set; }

    /// <summary>
    /// 0 انجام نشده
    /// 1 انجام شده
    /// 2 لغو شده
    /// </summary>
    public byte Status { get; set; }

    public string? Comment { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public int? BranchId { get; set; }
}
