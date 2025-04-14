using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VoteOnline.Domain.Entities;

public partial class VoteOnlineContext : DbContext
{
    public VoteOnlineContext()
    {
    }

    public VoteOnlineContext(DbContextOptions<VoteOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BieuQuyet> BieuQuyets { get; set; }

    public virtual DbSet<DinhDang> DinhDangs { get; set; }

    public virtual DbSet<MainAccount> MainAccounts { get; set; }

    public virtual DbSet<SubAccount> SubAccounts { get; set; }

    public virtual DbSet<VanDe> VanDes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRAVO\\SQL2022;Initial Catalog=VoteOnline;Integrated Security=SSPI; MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BieuQuyet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BieuQuye__3213E83F5628883D");

            entity.HasOne(d => d.IdsubAccountNavigation).WithMany(p => p.BieuQuyets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BieuQuyet__IDSub__5535A963");

            entity.HasOne(d => d.IdvanDeNavigation).WithMany(p => p.BieuQuyets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BieuQuyet__IDVan__534D60F1");
        });

        modelBuilder.Entity<DinhDang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DinhDang__3213E83F7A835766");
        });

        modelBuilder.Entity<MainAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MainAcco__3214EC07A2B07266");
        });

        modelBuilder.Entity<SubAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubAccou__3213E83F8F91EA16");

            entity.HasOne(d => d.IdmainAccountNavigation).WithMany(p => p.SubAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubAccoun__IDMai__5165187F");

            entity.HasOne(d => d.IdvanDeNavigation).WithMany(p => p.SubAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubAccoun__IDVan__5441852A");
        });

        modelBuilder.Entity<VanDe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VanDe__3213E83F4F96D9B9");

            entity.HasOne(d => d.IdMainAccountNavigation).WithMany(p => p.VanDes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VanDe__IdMainAcc__5629CD9C");

            entity.HasOne(d => d.IddinhDangNavigation).WithMany(p => p.VanDes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VanDe__IDDinhDan__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
