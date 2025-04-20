using System;
using System.Collections.Generic;
using BT_DBFirst.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BT_DBFirst.Data;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC074AF0DB67");

            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Mssv).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
