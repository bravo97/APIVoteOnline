using System;
using System.Collections.Generic;

namespace VoteOnline.Domain.Entities;

public partial class MainAccount
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public bool? Lock { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? HoTen { get; set; }

    public string? Token { get; set; }

    public DateTime? DateCreate { get; set; }

    public string? CustomCode { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual ICollection<VanDe> VanDes { get; set; } = new List<VanDe>();
}
