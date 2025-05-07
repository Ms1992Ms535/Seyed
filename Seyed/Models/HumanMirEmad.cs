using System;
using System.Collections.Generic;

namespace Seyed.Models;

public partial class HumanMirEmad
{
    public int HumanId { get; set; }

    public string? HumanName { get; set; }

    public string? Family { get; set; }

    public string? FatherName { get; set; }

    public string? RegNo { get; set; }

    public string? NationalNo { get; set; }

    public string? RegPlace { get; set; }

    public string? Job { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool Sex { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public string? RegSerial { get; set; }

    public string? BirthPlace { get; set; }

    public byte[] TimeStamp { get; set; } = null!;

    public string? LatinName { get; set; }

    public string? LatinFamily { get; set; }

    public int? NationalId { get; set; }

    public int? UserId { get; set; }

    public long? OriginalId { get; set; }

    public long? OriginalBranchId { get; set; }

    public int? EducationId { get; set; }

    public bool? Marriage { get; set; }

    public int? ReligionId { get; set; }

    public string? NickName { get; set; }

    public byte? SpecialCondId { get; set; }

    public bool? Pic { get; set; }

    public bool? Finger { get; set; }

    public DateTime? ModifyDate { get; set; }

    public byte? CategoryId { get; set; }

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
}
