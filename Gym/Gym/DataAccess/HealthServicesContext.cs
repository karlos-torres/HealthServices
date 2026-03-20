using System;
using System.Collections.Generic;
using Gym.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess;

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
            entity.HasOne(d => d.Teacher).WithMany(p => p.BoxSchedules)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_BoxSchedules_BoxTeachers");

            entity.HasMany(d => d.Members).WithMany(p => p.BoxSchedules)
                .UsingEntity<Dictionary<string, object>>(
                    "BoxSchedulesMember",
                    r => r.HasOne<Member>().WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BoxSchedulesMembers_Members"),
                    l => l.HasOne<BoxSchedule>().WithMany()
                        .HasForeignKey("BoxScheduleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BoxSchedulesMembers_BoxSchedules"),
                    j =>
                    {
                        j.HasKey("BoxScheduleId", "MemberId");
                        j.ToTable("BoxSchedulesMembers");
                    });
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

            entity.HasOne(d => d.Goal).WithMany(p => p.Members)
                .HasForeignKey(d => d.GoalId)
                .HasConstraintName("FK_Members_Goals");
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
