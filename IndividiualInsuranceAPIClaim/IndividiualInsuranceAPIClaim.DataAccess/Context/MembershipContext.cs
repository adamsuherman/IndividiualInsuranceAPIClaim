using System;
using System.Collections.Generic;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Membership;
using Microsoft.EntityFrameworkCore;

namespace IndividiualInsuranceAPIClaim.DataAccess.Context;

public partial class MembershipContext : DbContext
{
    public MembershipContext(DbContextOptions<MembershipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPeserta> TblPeserta { get; set; }

    public virtual DbSet<msNationality> msNationality { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPeserta>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.CardNumber).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NationalIdNumber).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Plafond).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PolicyNumber).HasMaxLength(50);
            entity.Property(e => e.Premi).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<msNationality>(entity =>
        {
            entity.HasKey(e => e.NationalityId);

            entity.Property(e => e.NationalityId).ValueGeneratedNever();
            entity.Property(e => e.NationalityName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
