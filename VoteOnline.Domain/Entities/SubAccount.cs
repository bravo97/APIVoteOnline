using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VoteOnline.Domain.Entities;

[Table("SubAccount")]
public partial class SubAccount
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("IDMainAccount")]
    public int IdmainAccount { get; set; }

    [StringLength(1)]
    public string HoTen { get; set; } = null!;

    [StringLength(1)]
    public string DienThoai { get; set; } = null!;

    [Column("CMND")]
    [StringLength(1)]
    public string Cmnd { get; set; } = null!;

    [Column("IDVanDe")]
    public int IdvanDe { get; set; }

    [Column("KhoaBM")]
    [StringLength(1)]
    [Unicode(false)]
    public string KhoaBm { get; set; } = null!;

    [InverseProperty("IdsubAccountNavigation")]
    public virtual ICollection<BieuQuyet> BieuQuyets { get; set; } = new List<BieuQuyet>();

    [ForeignKey("IdmainAccount")]
    [InverseProperty("SubAccounts")]
    public virtual MainAccount IdmainAccountNavigation { get; set; } = null!;

    [ForeignKey("IdvanDe")]
    [InverseProperty("SubAccounts")]
    public virtual VanDe IdvanDeNavigation { get; set; } = null!;
}
