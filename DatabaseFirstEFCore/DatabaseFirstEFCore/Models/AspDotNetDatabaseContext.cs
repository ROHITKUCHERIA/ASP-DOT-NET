using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstEFCore.Models;

namespace DatabaseFirstEFCore.Models;

public partial class AspDotNetDatabaseContext : DbContext
{
    public AspDotNetDatabaseContext()
    {
    }

    public AspDotNetDatabaseContext(DbContextOptions<AspDotNetDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) { 
        
        }
    }   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudenGender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<DatabaseFirstEFCore.Models.Employee> Employee { get; set; } = default!;
}
