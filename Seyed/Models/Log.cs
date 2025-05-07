using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Log
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public int UserId { get; set; }

    public int? EntityId { get; set; }

    public int? ActionTypeId { get; set; }

    public long? RecordId { get; set; }

    public string? Message { get; set; }

    public int? SubEntityId { get; set; }
}
