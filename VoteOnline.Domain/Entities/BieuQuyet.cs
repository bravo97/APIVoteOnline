using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VoteOnline.Domain.Entities;

[Table("BieuQuyet")]
public partial class BieuQuyet
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("IDVanDe")]
    public int IdvanDe { get; set; }

    [Column("IDSubAccount")]
    public int IdsubAccount { get; set; }

    public double DongY { get; set; }

    public double KhongDongY { get; set; }

    [Column("KhongYKien")]
    public double KhongYkien { get; set; }

    public double NhapSo { get; set; }

    [Column("YKien")]
    [StringLength(1)]
    public string Ykien { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date2 { get; set; }

    [StringLength(1)]
    public string Device { get; set; } = null!;

    [ForeignKey("IdsubAccount")]
    [InverseProperty("BieuQuyets")]
    public virtual SubAccount IdsubAccountNavigation { get; set; } = null!;

    [ForeignKey("IdvanDe")]
    [InverseProperty("BieuQuyets")]
    public virtual VanDe IdvanDeNavigation { get; set; } = null!;
}
