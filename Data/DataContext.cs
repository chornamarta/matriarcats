using System;
using Data.Models;
using Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudCourse> StudCourses { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.GetConnectionString();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudCourse>().HasKey(u => new { u.StudId, u.CourseId });
            modelBuilder
                .Entity<Courses>()
                .Property(e => e.Years)
                .HasConversion(
                    v => v.ToString(),
                    v => (Years)Enum.Parse(typeof(Years), v));

            modelBuilder
                .Entity<Courses>()
                .Property(e => e.Specialities)
                .HasConversion(
                    v => v.ToString(),
                    v => (Specialities)Enum.Parse(typeof(Specialities), v));

            modelBuilder
                .Entity<Courses>()
                .Property(e => e.Semester)
                .HasConversion(
                    v => v.ToString(),
                    v => (Semester)Enum.Parse(typeof(Semester), v));

            modelBuilder
                .Entity<Teacher>()
                .Property(e => e.TeacherStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (TeacherStatus)Enum.Parse(typeof(TeacherStatus), v));

            modelBuilder
                .Entity<StudCourse>()
                .Property(e => e.Semester)
                .HasConversion(
                    v => v.ToString(),
                    v => (Semester)Enum.Parse(typeof(Semester), v));

        }
    }
}