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

    public virtual DbSet<MainAccount> MainAccounts { get; set; }

    public virtual DbSet<PhuongAn> PhuongAns { get; set; }

    public virtual DbSet<SubAccount> SubAccounts { get; set; }

    public virtual DbSet<VanDe> VanDes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRAVO\\SQL2022;Initial Catalog=VoteOnline;Integrated Security=SSPI; MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BieuQuyet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BieuQuye__3214EC07AF562138");

            entity.ToTable("BieuQuyet");

            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Device).HasMaxLength(100);
            entity.Property(e => e.IdphuongAn).HasColumnName("IDPhuongAn");
            entity.Property(e => e.IdsubAccount).HasColumnName("IDSubAccount");
            entity.Property(e => e.IdvanDe).HasColumnName("IDVanDe");

            entity.HasOne(d => d.IdvanDeNavigation).WithMany(p => p.BieuQuyets)
                .HasForeignKey(d => d.IdvanDe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BieuQuyet__IDVan__0E6E26BF");
        });

        modelBuilder.Entity<MainAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MainAcco__3214EC075B17914C");

            entity.ToTable("MainAccount");

            entity.Property(e => e.CustomCode)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DienThoai).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.RefreshToken).HasMaxLength(20);
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(20);
        });

        modelBuilder.Entity<PhuongAn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhuongAn__3214EC0753482AC7");

            entity.ToTable("PhuongAn");

            entity.Property(e => e.IdvanDe).HasColumnName("IDVanDe");
            entity.Property(e => e.Ten).HasMaxLength(100);

            entity.HasOne(d => d.IdvanDeNavigation).WithMany(p => p.PhuongAns)
                .HasForeignKey(d => d.IdvanDe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhuongAn__IDVanD__0C85DE4D");
        });

        modelBuilder.Entity<SubAccount>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Code }).HasName("PK__SubAccou__3214EC0767A4F5C0");

            entity.ToTable("SubAccount");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Code).HasMaxLength(11);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DienThoai).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.ResfreshToken).HasMaxLength(10);
            entity.Property(e => e.Token).HasMaxLength(10);
        });

        modelBuilder.Entity<VanDe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VanDe__3214EC070D6907F0");

            entity.ToTable("VanDe");

            entity.Property(e => e.Code).HasMaxLength(11);
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TenVd)
                .HasMaxLength(200)
                .HasColumnName("TenVD");

            entity.HasOne(d => d.IdMainAccountNavigation).WithMany(p => p.VanDes)
                .HasForeignKey(d => d.IdMainAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VanDe__IdMainAcc__09A971A2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
