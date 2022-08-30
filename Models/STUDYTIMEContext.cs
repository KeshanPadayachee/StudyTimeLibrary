using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudyTimeLibrary.Models
{
    public partial class STUDYTIMEContext : DbContext
    {
        public STUDYTIMEContext()
        {
        }

        public STUDYTIMEContext(DbContextOptions<STUDYTIMEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudyRecord> StudyRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=STUDYTIME;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULE");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.ClassHours)
                    .HasColumnType("decimal(8, 1)")
                    .HasColumnName("CLASS_HOURS");

                entity.Property(e => e.ModuleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MODULE_CODE");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODULE_NAME");

                entity.Property(e => e.NumberCredits).HasColumnName("NUMBER_CREDITS");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MODULE__STUDENT___286302EC");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("SEMESTER");

                entity.Property(e => e.SemesterId).HasColumnName("SEMESTER_ID");

                entity.Property(e => e.NumWeeks).HasColumnName("NUM_WEEKS");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Semesters)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SEMESTER__STUDEN__25869641");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.Property(e => e.CellNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CELL_NUMBER");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD_HASH");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD_SALT");

                entity.Property(e => e.StudentNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_NUMBER");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME");
            });

            modelBuilder.Entity<StudyRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__STUDY_RE__E2DA602F2EC0C25C");

                entity.ToTable("STUDY_RECORD");

                entity.Property(e => e.RecordId).HasColumnName("RECORD_ID");

                entity.Property(e => e.DateStudied)
                    .HasColumnType("date")
                    .HasColumnName("DATE_STUDIED");

                entity.Property(e => e.HoursStudied)
                    .HasColumnType("decimal(8, 1)")
                    .HasColumnName("HOURS_STUDIED");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.StudyRecords)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDY_REC__HOURS__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
