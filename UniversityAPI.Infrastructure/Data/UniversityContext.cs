using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Domain.Entities;

namespace UniversityAPI.Infrastructure.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.EnrolledSubjects)
                .WithMany(sub => sub.EnrolledStudents)
                .UsingEntity<Enrollment>(
                    j => j
                        .HasOne(e => e.Subject)
                        .WithMany()
                        .HasForeignKey(e => e.SubjectId),
                    j => j
                        .HasOne(e => e.Student)
                        .WithMany()
                        .HasForeignKey(e => e.StudentId),
                    j =>
                    {
                        j.HasKey(e => new { e.StudentId, e.SubjectId });
                        j.Property(e => e.EnrollmentDate).IsRequired();
                    });

            // Configure Subject entity
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(e => e.Lectures)
                      .WithOne(l => l.Subject)
                      .HasForeignKey(l => l.SubjectId);
            });

            // Configure Lecture entity
            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DayOfWeek).IsRequired();
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.Duration).IsRequired();

                entity.HasOne(e => e.Subject)
                      .WithMany(s => s.Lectures)
                      .HasForeignKey(e => e.SubjectId);

                entity.HasOne(e => e.LectureTheatre)
                      .WithMany()
                      .HasForeignKey(e => e.LectureTheatreId);
            });

            // Configure LectureTheatre entity
            modelBuilder.Entity<LectureTheatre>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Capacity).IsRequired();
            });

            // Configure Enrollment entity
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.SubjectId });
                entity.Property(e => e.EnrollmentDate).IsRequired();
            });
        }
    }
}