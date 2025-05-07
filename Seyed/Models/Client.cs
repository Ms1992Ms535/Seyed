using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Client
{
    /// <summary>
    /// شناسه جدول
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// نوع مشتری : 1: حقوقی   2:حقیقی    3: مشترک
    /// </summary>
    public byte RefType { get; set; }

    /// <summary>
    /// کلید خارجی شناسه جدولhuman or Company
    /// </summary>
    public int RefId { get; set; }

    /// <summary>
    /// شماره مشتری
    /// </summary>
    public long? CustomerNo { get; set; }

    /// <summary>
    /// شناسه مرکز هزینه مشتری
    /// </summary>
    public long? CostCenterId { get; set; }

    public byte Status { get; set; }

    public long? OldCustomerNo { get; set; }

    public long? OriginalId { get; set; }

    public long? OriginalBreanchId { get; set; }

    public int? BranchId { get; set; }

    public string? Codem { get; set; }

    public int? SanaStatus { get; set; }

    public string? About { get; set; }

    public long? MirEmadHumanId { get; set; }

    public long? MirEmadClientId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<BlackList> BlackLists { get; set; } = new List<BlackList>();

    public virtual ICollection<ClientMerge> ClientMerges { get; set; } = new List<ClientMerge>();

    public virtual ICollection<CreditWorthiness> CreditWorthinesses { get; set; } = new List<CreditWorthiness>();

    public virtual ICollection<CustomerFile> CustomerFiles { get; set; } = new List<CustomerFile>();

    public virtual ICollection<OwnerSignature> OwnerSignatures { get; set; } = new List<OwnerSignature>();

    public virtual Company Ref { get; set; } = null!;

    public virtual Human RefNavigation { get; set; } = null!;
}
