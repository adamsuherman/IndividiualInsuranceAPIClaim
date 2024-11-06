using System;
using System.Collections.Generic;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;
using Microsoft.EntityFrameworkCore;

namespace IndividiualInsuranceAPIClaim.DataAccess.Context;

public partial class ClaimContext : DbContext
{
    public ClaimContext(DbContextOptions<ClaimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<msDiagnosa> msDiagnosa { get; set; }

    public virtual DbSet<trClaim> trClaim { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<msDiagnosa>(entity =>
        {
            entity.HasKey(e => e.DiagonosaCode);

            entity.Property(e => e.DiagonosaCode).HasMaxLength(10);
            entity.Property(e => e.DiagonsaName).HasMaxLength(50);
        });

        modelBuilder.Entity<trClaim>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.CardNumber).HasMaxLength(50);
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DiagonosaCode).HasMaxLength(10);
            entity.Property(e => e.TreatmentDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
