using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Nutrition.Entities;

namespace Nutrition.DataAccess;

public partial class HealthServicesContext : DbContext
{
    public HealthServicesContext()
    {
    }

    public HealthServicesContext(DbContextOptions<HealthServicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BoxSchedule> BoxSchedules { get; set; }

    public virtual DbSet<BoxSchedulesMember> BoxSchedulesMembers { get; set; }

    public virtual DbSet<BoxTeacher> BoxTeachers { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Nutritionist> Nutritionists { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoxSchedule>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BoxSchedulesMember>(entity =>
        {
            entity.HasKey(e => new { e.BoxScheduleId, e.MemberId });
        });

        modelBuilder.Entity<BoxTeacher>(entity =>
        {
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.Property(e => e.Goal1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Goal");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nutritionist>(entity =>
        {
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasMany(d => d.Patients).WithMany(p => p.Nutritionists)
                .UsingEntity<Dictionary<string, object>>(
                    "NutritionistsPatient",
                    r => r.HasOne<Member>().WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_NutritionistsPatients_Members"),
                    l => l.HasOne<Nutritionist>().WithMany()
                        .HasForeignKey("NutritionistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_NutritionistsPatients_Nutritionists"),
                    j =>
                    {
                        j.HasKey("NutritionistId", "PatientId");
                        j.ToTable("NutritionistsPatients");
                    });
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
