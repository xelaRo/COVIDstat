using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Infrastructure.COVIDstat.EntityFramework
{
    public partial class CovidStatDBContext : DbContext
    {
        public CovidStatDBContext()
        {
        }

        public CovidStatDBContext(DbContextOptions<CovidStatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientTest> PatientTest { get; set; }
        public virtual DbSet<PatientXsymptom> PatientXsymptom { get; set; }
        public virtual DbSet<Symptom> Symptom { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ALEXPC;Database=CovidStatDB;User Id=sa;Password=defcon89#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<County>(entity =>
            {
                entity.Property(e => e.CountyId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.CountyId)
                    .HasName("IX_Patient_DistrictId");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.PatientId).ValueGeneratedNever();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_Patient_District_DistrictId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PatientTest>(entity =>
            {
                entity.Property(e => e.PatientTestId).ValueGeneratedNever();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientTest)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientTest_Patient");
            });

            modelBuilder.Entity<PatientXsymptom>(entity =>
            {
                entity.ToTable("PatientXSymptom");

                entity.HasIndex(e => e.PatientId);

                entity.HasIndex(e => e.SymptomId);

                entity.Property(e => e.PatientXsymptomId)
                    .HasColumnName("PatientXSymptomId")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientXsymptom)
                    .HasForeignKey(d => d.PatientId);

                entity.HasOne(d => d.Symptom)
                    .WithMany(p => p.PatientXsymptom)
                    .HasForeignKey(d => d.SymptomId);
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.Property(e => e.SymptomId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
