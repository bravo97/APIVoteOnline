using System;
using System.Collections.Generic;

namespace VoteOnline.Domain.Entities;

public partial class SubAccount
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string? Email { get; set; }

    public string? Token { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? DateCreate { get; set; }

    public string? ResfreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public DateTime? ExpiryDate { get; set; }
}
