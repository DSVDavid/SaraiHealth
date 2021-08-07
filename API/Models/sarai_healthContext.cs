using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class sarai_healthContext : DbContext
    {
        public sarai_healthContext()
        {
        }

        public sarai_healthContext(DbContextOptions<sarai_healthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaregiverToPatient> CaregiverToPatient { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<PatientData> PatientData { get; set; }
        public virtual DbSet<PatientTreatment> PatientTreatment { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercache { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<TreatmentMedication> TreatmentMedication { get; set; }
        public virtual DbSet<UserPatient> UserPatient { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<CaregiverToPatient>(entity =>
            {
                entity.ToTable("caregiver_to_patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCaregiver).HasColumnName("id_caregiver");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.HasOne(d => d.IdCaregiverNavigation)
                    .WithMany(p => p.CaregiverToPatientIdCaregiverNavigation)
                    .HasForeignKey(d => d.IdCaregiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_caregiver");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.CaregiverToPatientIdPatientNavigation)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_patient");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("medication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dosage)
                    .HasColumnName("dosage")
                    .HasColumnType("numeric");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.SideEffects)
                    .HasColumnName("side_effects")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<PatientData>(entity =>
            {
                entity.ToTable("patient_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Activity)
                    .HasColumnName("activity")
                    .HasColumnType("character varying");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.PatientData)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_patient");
            });

            modelBuilder.Entity<PatientTreatment>(entity =>
            {
                entity.ToTable("patient_treatment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.Property(e => e.IdTreatment).HasColumnName("id_treatment");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.PatientTreatment)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_patient");

                entity.HasOne(d => d.IdTreatmentNavigation)
                    .WithMany(p => p.PatientTreatment)
                    .HasForeignKey(d => d.IdTreatment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_treatment");
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnName("reldatabase")
                    .HasColumnType("oid");

                entity.Property(e => e.Relfilenode)
                    .HasColumnName("relfilenode")
                    .HasColumnType("oid");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnName("reltablespace")
                    .HasColumnType("oid");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnName("dbid")
                    .HasColumnType("oid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("oid");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("treatment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<TreatmentMedication>(entity =>
            {
                entity.ToTable("treatment_medication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndHour).HasColumnName("end_hour");

                entity.Property(e => e.IdMedication).HasColumnName("id_medication");

                entity.Property(e => e.IdTreatment).HasColumnName("id_treatment");

                entity.Property(e => e.StartHour).HasColumnName("start_hour");

                entity.Property(e => e.Taken).HasColumnName("taken");

                entity.Property(e => e.TreatDate).HasColumnType("date");

                entity.HasOne(d => d.IdMedicationNavigation)
                    .WithMany(p => p.TreatmentMedication)
                    .HasForeignKey(d => d.IdMedication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_medication");

                entity.HasOne(d => d.IdTreatmentNavigation)
                    .WithMany(p => p.TreatmentMedication)
                    .HasForeignKey(d => d.IdTreatment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_treatment");
            });

            modelBuilder.Entity<UserPatient>(entity =>
            {
                entity.ToTable("user_patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.MedicalRecord)
                    .HasColumnName("medical_record")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPatient)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_user");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("character varying");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
