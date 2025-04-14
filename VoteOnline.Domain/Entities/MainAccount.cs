using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VoteOnline.Domain.Entities;

[Table("MainAccount")]
public partial class MainAccount
{
    [Key]
    public int Id { get; set; }

    [StringLength(1)]
    public string UserName { get; set; } = null!;

    [StringLength(1)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime LastLogin { get; set; }

    public bool Lock { get; set; }

    [StringLength(1)]
    public string DienThoai { get; set; } = null!;

    [StringLength(1)]
    public string Email { get; set; } = null!;

    [StringLength(1)]
    public string HoTen { get; set; } = null!;

    [StringLength(1)]
    public string Token { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateCreate { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string CustomCode { get; set; } = null!;

    [StringLength(1)]
    public string RefreshToken { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RefreshTokenExpiryTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpiryDate { get; set; }

    [InverseProperty("IdmainAccountNavigation")]
    public virtual ICollection<SubAccount> SubAccounts { get; set; } = new List<SubAccount>();

    [InverseProperty("IdMainAccountNavigation")]
    public virtual ICollection<VanDe> VanDes { get; set; } = new List<VanDe>();
}
