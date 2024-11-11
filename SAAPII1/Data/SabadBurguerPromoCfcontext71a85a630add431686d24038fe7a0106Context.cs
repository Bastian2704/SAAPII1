using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SAAPII1.Data.Models;

namespace SAAPII1.Data;

public partial class SabadBurguerPromoCfcontext71a85a630add431686d24038fe7a0106Context : DbContext
{
    public SabadBurguerPromoCfcontext71a85a630add431686d24038fe7a0106Context()
    {
    }

    public SabadBurguerPromoCfcontext71a85a630add431686d24038fe7a0106Context(DbContextOptions<SabadBurguerPromoCfcontext71a85a630add431686d24038fe7a0106Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Burguer> Burguers { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SAbadBurguerPromoCFContext-71a85a63-0add-4316-86d2-4038fe7a0106");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burguer>(entity =>
        {
            entity.ToTable("Burguer");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.BurguerId, "IX_Promo_BurguerID");

            entity.Property(e => e.PromoId).HasColumnName("PromoID");
            entity.Property(e => e.BurguerId).HasColumnName("BurguerID");

            entity.HasOne(d => d.Burguer).WithMany(p => p.Promos).HasForeignKey(d => d.BurguerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
