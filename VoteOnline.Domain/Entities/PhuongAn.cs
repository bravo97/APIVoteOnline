using System;
using System.Collections.Generic;

namespace VoteOnline.Domain.Entities;

public partial class PhuongAn
{
    public int Id { get; set; }

    public int IdvanDe { get; set; }

    public string? Ten { get; set; }

    public virtual VanDe IdvanDeNavigation { get; set; } = null!;
}
