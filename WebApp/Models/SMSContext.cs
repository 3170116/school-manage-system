using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absence> Absence { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Domain> Domain { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studentsperclassroom> Studentsperclassroom { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Teachersperschool> Teachersperschool { get; set; }
        public virtual DbSet<Teachinghour> Teachinghour { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=dimitris_bek;database=school_management_system", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("absence");

                entity.HasIndex(e => e.StudentId)
                    .HasName("studentId");

                entity.HasIndex(e => e.TeachingHourId)
                    .HasName("teachingHourId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsPunishment).HasColumnName("isPunishment");

                entity.Property(e => e.Justified).HasColumnName("justified");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TeachingHourId).HasColumnName("teachingHourId");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("absence_ibfk_1");

                entity.HasOne(d => d.TeachingHour)
                    .WithMany()
                    .HasForeignKey(d => d.TeachingHourId)
                    .HasConstraintName("absence_ibfk_2");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("certificate");

                entity.HasIndex(e => e.StudentId)
                    .HasName("studentId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinalDegree).HasColumnName("finalDegree");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("certificate_ibfk_1");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("classroom");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classId");

                entity.HasIndex(e => e.DomainId)
                    .HasName("domainId");

                entity.HasIndex(e => e.SchoolId)
                    .HasName("schoolId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.DomainId).HasColumnName("domainId");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SchoolId).HasColumnName("schoolId");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Classroom)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("classroom_ibfk_2");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Classroom)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("classroom_ibfk_3");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Classroom)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("classroom_ibfk_1");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classId");

                entity.HasIndex(e => e.DomainId)
                    .HasName("domainId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.DomainId).HasColumnName("domainId");

                entity.Property(e => e.HoursPerWeek).HasColumnName("hoursPerWeek");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("course_ibfk_1");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("course_ibfk_2");
            });

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.ToTable("domain");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grade");

                entity.HasIndex(e => e.CourseId)
                    .HasName("courseId");

                entity.HasIndex(e => e.StudentId)
                    .HasName("studentId");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("teacherId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Grade1).HasColumnName("grade");

                entity.Property(e => e.Semester).HasColumnName("semester");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("grade_ibfk_3");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("grade_ibfk_1");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("grade_ibfk_2");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("school");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasColumnName("area")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("fullName")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.SchoolId)
                    .HasName("schoolId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MaximumJustifiedAbsences)
                    .HasColumnName("maximumJustifiedAbsences")
                    .HasDefaultValueSql("'57'");

                entity.Property(e => e.MaximumUnJustifiedAbsences)
                    .HasColumnName("maximumUnJustifiedAbsences")
                    .HasDefaultValueSql("'142'");

                entity.Property(e => e.SchoolId).HasColumnName("schoolId");
            });

            modelBuilder.Entity<Studentsperclassroom>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ClassroomId })
                    .HasName("PRIMARY");

                entity.ToTable("studentsperclassroom");

                entity.HasIndex(e => e.ClassroomId)
                    .HasName("classroomId");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.ClassroomId).HasColumnName("classroomId");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Studentsperclassroom)
                    .HasForeignKey(d => d.ClassroomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("studentsperclassroom_ibfk_2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Studentsperclassroom)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("studentsperclassroom_ibfk_1");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Speciality)
                    .HasColumnName("speciality")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Teachersperschool>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.SchoolId })
                    .HasName("PRIMARY");

                entity.ToTable("teachersperschool");

                entity.HasIndex(e => e.SchoolId)
                    .HasName("schoolId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.SchoolId).HasColumnName("schoolId");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Teachersperschool)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teachersperschool_ibfk_2");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Teachersperschool)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teachersperschool_ibfk_1");
            });

            modelBuilder.Entity<Teachinghour>(entity =>
            {
                entity.ToTable("teachinghour");

                entity.HasIndex(e => e.ClassroomId)
                    .HasName("classroomId");

                entity.HasIndex(e => e.CourseId)
                    .HasName("courseId");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("teacherId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassroomId).HasColumnName("classroomId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Hour).HasColumnName("hour");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Teachinghour)
                    .HasForeignKey(d => d.ClassroomId)
                    .HasConstraintName("teachinghour_ibfk_2");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Teachinghour)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("teachinghour_ibfk_3");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Teachinghour)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("teachinghour_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        //custom methods
        public bool ContainsAccount(Teacher teacher)
        {
            if (teacher.Email == null)
                return false;

            if (teacher.Password == null)
                return false;

            return Teacher.FirstOrDefaultAsync(x => x.Email.Equals(teacher.Email) && x.Password.Equals(teacher.Password)).Result != null ? true : false;
        }

        public bool ContainsAccountWithEmail(string email)
        {
            return Teacher.FirstOrDefaultAsync(x => x.Email.Equals(email)).Result != null ? true : false;
        }

        public bool ContainsSchool(School school)
        {
            if (school.FullName == null)
                return false;

            return School.FirstOrDefaultAsync(x => x.FullName.Trim().ToLower() == school.FullName.Trim().ToString()).Result != null ? true : false;
        }

        public bool ContainsTeacher(Teacher teacher)
        {
            if (teacher.Email == null)
                return false;

            return Teacher.FirstOrDefaultAsync(x => x.Email.Equals(teacher.Email)).Result != null ? true : false;
        }

        public int getNextTeacherId()
        {
            return Teacher.MaxAsync(x => x.Id).Result + 1;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            Teacher teacher = Teacher.FirstOrDefaultAsync(x => x.Id == teacherId).Result;

            if (teacher == null)
                return null;

            return Models.Teacher.getObjectByRole(teacher);
        }

        public void UpdateValues(Teacher newTeacher)
        {
            Teacher oldTeacher = Teacher.Find(newTeacher.Id);

            if (oldTeacher == null)
                return;

            Entry(oldTeacher).CurrentValues.SetValues(newTeacher);
        }
    }
}
