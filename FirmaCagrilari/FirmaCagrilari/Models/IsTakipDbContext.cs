using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirmaCagrilari.Models;

public partial class IsTakipDbContext : DbContext
{
    public IsTakipDbContext()
    {
    }

    public IsTakipDbContext(DbContextOptions<IsTakipDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblCagriDetay> TblCagriDetays { get; set; }

    public virtual DbSet<TblCagrilar> TblCagrilars { get; set; }

    public virtual DbSet<TblDepartmanlar> TblDepartmanlars { get; set; }

    public virtual DbSet<TblFirmalar> TblFirmalars { get; set; }

    public virtual DbSet<TblGorevDetay> TblGorevDetays { get; set; }

    public virtual DbSet<TblGorevler> TblGorevlers { get; set; }

    public virtual DbSet<TblMesajlar> TblMesajlars { get; set; }

    public virtual DbSet<TblPersoneller> TblPersonellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=IsTakipDb; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.ToTable("TblAdmin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Kullanici).HasMaxLength(30);
            entity.Property(e => e.Sifre).HasMaxLength(30);
        });

        modelBuilder.Entity<TblCagriDetay>(entity =>
        {
            entity.ToTable("TblCagriDetay");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama).HasMaxLength(250);
            entity.Property(e => e.Saat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tarih).HasColumnType("date");

            entity.HasOne(d => d.CagriNavigation).WithMany(p => p.TblCagriDetays)
                .HasForeignKey(d => d.Cagri)
                .HasConstraintName("FK_TblCagriDetay_TblCagrilar");
        });

        modelBuilder.Entity<TblCagrilar>(entity =>
        {
            entity.ToTable("TblCagrilar");

            entity.HasIndex(e => e.CagriFirma, "iCagriFirma_TblCagrilar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Konu).HasMaxLength(50);
            entity.Property(e => e.Tarih).HasColumnType("date");

            entity.HasOne(d => d.CagriFirmaNavigation).WithMany(p => p.TblCagrilars)
                .HasForeignKey(d => d.CagriFirma)
                .HasConstraintName("FK_TblCagrilar_TblFirmalar");
        });

        modelBuilder.Entity<TblDepartmanlar>(entity =>
        {
            entity.ToTable("TblDepartmanlar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<TblFirmalar>(entity =>
        {
            entity.ToTable("TblFirmalar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Competent)
                .HasMaxLength(30)
                .HasColumnName("competent");
            entity.Property(e => e.District)
                .HasMaxLength(30)
                .HasColumnName("district");
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("number");
            entity.Property(e => e.Province)
                .HasMaxLength(30)
                .HasColumnName("province");
            entity.Property(e => e.Sector).HasMaxLength(30);
            entity.Property(e => e.Sifre).HasMaxLength(20);
        });

        modelBuilder.Entity<TblGorevDetay>(entity =>
        {
            entity.ToTable("TblGorevDetay");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.Saat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tarih).HasColumnType("date");

            entity.HasOne(d => d.GorevNavigation).WithMany(p => p.TblGorevDetays)
                .HasForeignKey(d => d.Gorev)
                .HasConstraintName("FK_TblGorevDetay_TblGorevler");
        });

        modelBuilder.Entity<TblGorevler>(entity =>
        {
            entity.ToTable("TblGorevler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.Tarih).HasColumnType("date");

            entity.HasOne(d => d.GorevAlanNavigation).WithMany(p => p.TblGorevlerGorevAlanNavigations)
                .HasForeignKey(d => d.GorevAlan)
                .HasConstraintName("FK_TblGorevler_TblPersoneller");

            entity.HasOne(d => d.GorevVerenNavigation).WithMany(p => p.TblGorevlerGorevVerenNavigations)
                .HasForeignKey(d => d.GorevVeren)
                .HasConstraintName("FK_TblGorevler_TblPersoneller1");
        });

        modelBuilder.Entity<TblMesajlar>(entity =>
        {
            entity.ToTable("TblMesajlar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Konu).HasMaxLength(50);
            entity.Property(e => e.Tarih).HasColumnType("date");

            entity.HasOne(d => d.AliciNavigation).WithMany(p => p.TblMesajlarAliciNavigations)
                .HasForeignKey(d => d.Alici)
                .HasConstraintName("FK_TblMesajlar_TblFirmalar1");

            entity.HasOne(d => d.GonderenNavigation).WithMany(p => p.TblMesajlarGonderenNavigations)
                .HasForeignKey(d => d.Gonderen)
                .HasConstraintName("FK_TblMesajlar_TblFirmalar");
        });

        modelBuilder.Entity<TblPersoneller>(entity =>
        {
            entity.ToTable("TblPersoneller");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");

            entity.HasOne(d => d.DepartmanNavigation).WithMany(p => p.TblPersonellers)
                .HasForeignKey(d => d.Departman)
                .HasConstraintName("FK_TblPersoneller_TblDepartmanlar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
