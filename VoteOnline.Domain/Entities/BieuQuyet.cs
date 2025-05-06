using System;
using System.Collections.Generic;

namespace VoteOnline.Domain.Entities;

public partial class BieuQuyet
{
    public int Id { get; set; }

    public int IdvanDe { get; set; }

    public int IdsubAccount { get; set; }

    public int? NhapSo { get; set; }

    public DateTime? Date1 { get; set; }

    public DateTime? Date2 { get; set; }

    public string? Device { get; set; }

    public int? IdphuongAn { get; set; }

    public virtual VanDe IdvanDeNavigation { get; set; } = null!;
}
