using System;
using System.Collections.Generic;

namespace VoteOnline.Domain.Entities;

public partial class VanDe
{
    public int Id { get; set; }

    public string TenVd { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public int IdMainAccount { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<BieuQuyet> BieuQuyets { get; set; } = new List<BieuQuyet>();

    public virtual MainAccount IdMainAccountNavigation { get; set; } = null!;

    public virtual ICollection<PhuongAn> PhuongAns { get; set; } = new List<PhuongAn>();
}
