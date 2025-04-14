using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VoteOnline.Domain.Entities;

[Table("VanDe")]
public partial class VanDe
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("TenVD")]
    [StringLength(1)]
    public string TenVd { get; set; } = null!;

    [StringLength(1)]
    public string MoTa { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NgayBatDau { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayKetThuc { get; set; }

    [Column("IDDinhDang")]
    public int IddinhDang { get; set; }

    public int IdMainAccount { get; set; }

    [InverseProperty("IdvanDeNavigation")]
    public virtual ICollection<BieuQuyet> BieuQuyets { get; set; } = new List<BieuQuyet>();

    [ForeignKey("IdMainAccount")]
    [InverseProperty("VanDes")]
    public virtual MainAccount IdMainAccountNavigation { get; set; } = null!;

    [ForeignKey("IddinhDang")]
    [InverseProperty("VanDes")]
    public virtual DinhDang IddinhDangNavigation { get; set; } = null!;

    [InverseProperty("IdvanDeNavigation")]
    public virtual ICollection<SubAccount> SubAccounts { get; set; } = new List<SubAccount>();
}
