using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedApp_Api.DatabaseModels;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<InformationDoctor> InformationDoctors { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInformation> UserInformations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => new { e.RecordId, e.PatientId });

            entity.Property(e => e.RecordId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.PatientId)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DoctorId)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Doctor).WithMany(p => p.AppointmentDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Appointments_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.AppointmentPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_User");
        });

        modelBuilder.Entity<InformationDoctor>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("InformationDoctor");

            entity.Property(e => e.UserId)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Speciality)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.InformationDoctor)
                .HasForeignKey<InformationDoctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InformationDoctor_User");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => new { e.RecordId, e.AppointmentId, e.PatientId });

            entity.ToTable("Prescription");

            entity.Property(e => e.RecordId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.AppointmentId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.PatientId)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Medicines)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Periodicity)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => new { d.AppointmentId, d.PatientId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Appointment");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.HasMany(d => d.Users).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRoles_User"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRoles_Role"),
                    j =>
                    {
                        j.HasKey("RoleId", "UserId");
                        j.ToTable("UserRoles");
                        j.IndexerProperty<string>("RoleId")
                            .HasMaxLength(1)
                            .IsUnicode(false)
                            .IsFixedLength();
                        j.IndexerProperty<string>("UserId")
                            .HasMaxLength(12)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.Property(e => e.RuleId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Alphanumeric1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Alphanumeric2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Range)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Time1).HasColumnType("datetime");
            entity.Property(e => e.Time2).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserInformation>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RecordId }).HasName("PK_User_Information");

            entity.ToTable("UserInformation");

            entity.Property(e => e.UserId)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.RecordId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.VitalSigns)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.UserInformations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInformation_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
