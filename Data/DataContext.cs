using System;
using Data.Models;
using Data.Models.Enums;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public Repository<Student> StudentRepository { get; set; }
        public Repository<Courses> CoursesRepository { get; set; } 
        public Repository<Teacher> TeacherRepository { get; set; }
        public Repository<StudCourse> StudCourseRepository { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            StudentRepository = new Repository<Student>(this);
            CoursesRepository = new Repository<Courses>(this);
            TeacherRepository = new Repository<Teacher>(this);
            StudCourseRepository = new Repository<StudCourse>(this);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEnums(modelBuilder);
        }

        private void ConfigureEnums(ModelBuilder modelBuilder)
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
