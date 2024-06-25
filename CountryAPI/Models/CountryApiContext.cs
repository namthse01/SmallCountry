using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Models;

public partial class CountryApiContext : DbContext
{
    public CountryApiContext()
    {
    }

    public CountryApiContext(DbContextOptions<CountryApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Commune> Communes { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SE130257\\SQLEXPRESS;Database=CountryAPI;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<Commune>(entity =>
        {
            entity.ToTable("Commune");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommuneName).HasMaxLength(50);

            entity.HasOne(d => d.Town).WithMany(p => p.Communes)
                .HasForeignKey(d => d.TownId)
                .HasConstraintName("FK_Commune_Town");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.ToTable("District");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DistrictName).HasMaxLength(50);
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.ToTable("Town");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.TownName).HasMaxLength(50);

            entity.HasOne(d => d.District).WithMany(p => p.Towns)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK_Town_District");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
