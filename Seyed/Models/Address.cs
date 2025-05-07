using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class Address
{
    public int Id { get; set; }

    public byte AddressTypeId { get; set; }

    public int ClientId { get; set; }

    public bool Active { get; set; }

    public string? Address1 { get; set; }

    public string? PostalCode { get; set; }

    public string? CityCode { get; set; }

    public string? TelNo { get; set; }

    public DateTime CreateDate { get; set; }

    public int ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
    //public object Address { get; internal set; }
}
