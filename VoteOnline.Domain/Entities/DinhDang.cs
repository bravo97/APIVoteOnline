using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VoteOnline.Domain.Entities;

[Table("DinhDang")]
public partial class DinhDang
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(1)]
    public string Ma { get; set; } = null!;

    [StringLength(1)]
    public string MoTa { get; set; } = null!;

    [InverseProperty("IddinhDangNavigation")]
    public virtual ICollection<VanDe> VanDes { get; set; } = new List<VanDe>();
}
