using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class CustomerFile
{
    public int Id { get; set; }

    public int FileId { get; set; }

    public int ClientId { get; set; }

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Client Client { get; set; } = null!;
}
