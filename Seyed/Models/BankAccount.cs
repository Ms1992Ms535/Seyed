using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class BankAccount
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int? BankId { get; set; }

    public string? AccNo { get; set; }

    public string? ShebaNo { get; set; }

    public string? OwnerName { get; set; }

    public byte Status { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime ModifyDate { get; set; }

    public int ModifyBy { get; set; }
}
