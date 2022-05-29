using System;
using LFC.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LFC.DAL
{
    public class LFCDbContext : IdentityDbContext
    {
        public LFCDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourses> TeacherCourses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasPostgresEnum<TeacherRole>();
            //modelBuilder.HasPostgresEnum<Semester>();
            //modelBuilder.HasPostgresEnum<Year>();
            //modelBuilder.HasPostgresEnum<Specialities>();

            modelBuilder
                .Entity<Courses>()
                .Property(e => e.Year)
                .HasConversion(
                    v => v.ToString(),
                    v => (Year)Enum.Parse(typeof(Year), v));

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
                .Property(e => e.TeacherRole)
                .HasConversion(
                    v => v.ToString(),
                    v => (TeacherRole)Enum.Parse(typeof(TeacherRole), v));
            
            modelBuilder
                .Entity<User>()
                .Property(e => e.UserRole)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRole)Enum.Parse(typeof(UserRole), v));


            // modelBuilder.Entity<Student>().HasData(
            //     new Student[]
            //     {
            //         new Student
            //         {
            //             StudId = 1,
            //             Name = "Іван",
            //             Surname = "Іванович",
            //             Email = "ivan@gmail.com",
            //             Password = "ivan001",
            //             Group = "ПМІ-41",
            //             Specialities = Specialities.ComputerScience
            //         },
            //         new Student
            //         {
            //             StudId  = 2,
            //             Name = "Марта",
            //             Surname = "Чорна",
            //             Email = "marta@gmail.com",
            //             Password = "marta002",
            //             Group = "ПМІ-31",
            //             Specialities = Specialities.ComputerScience
            //         },
            //         new Student
            //         {
            //             StudId =3,
            //             Name = "Уля",
            //             Surname = "Костецька",
            //             Email = "ulya@gmail.com",
            //             Password = "ulya003",
            //             Group = "ПМП-41",
            //             Specialities = Specialities.AppliedMathemetics
            //         },
            //         new Student
            //         {
            //             StudId =4,
            //             Name = "Аля",
            //             Surname = "Сергієнко",
            //             Email = "alya@gmail.com",
            //             Password = "akya004",
            //             Group = "ПМО-31",
            //             Specialities = Specialities.AppliedMathemetics
            //         }
            //     });

            // modelBuilder.Entity<Courses>().HasData(
            //     new Courses[]
            //     {
            //         new Courses
            //         {
            //             CourseId = 1,
            //             CourseName = "Криптологія",
            //             CourseDescription = "На цьому дввс ви зможете вивчити...",
            //             Year = Year.Third,
            //             Semester = Semester.FirstSemester,
            //             Specialities = Specialities.ComputerScience
            //         },
            //         new Courses
            //         {
            //             CourseId = 2,
            //             CourseName = "Лінійна алгебра",
            //             CourseDescription = "На цьому дввс ви зможете вивчити...",
            //             Year = Year.Fourth,
            //             Semester = Semester.SecondSemester,
            //             Specialities = Specialities.AppliedMathemetics
            //         }
            //     });
            //
            // modelBuilder.Entity<Teacher>().HasData(
            //     new Teacher[]
            //     {
            //         new Teacher
            //         {
            //             TeachId = 1,
            //             FullName = "Малець Р.",
            //             TeacherRole = TeacherRole.Docent,
            //             Email = "mal1@gmail.com",
            //             Password = "mal1"
            //         },
            //         new Teacher
            //         {
            //             TeachId  = 2,
            //             FullName = "Костів В.",
            //             TeacherRole = TeacherRole.Proffesor,
            //             Email = "kost1@gmail.com",
            //             Password = "kost1"
            //         }
            //     });

            modelBuilder.Entity<Courses>()
                .HasMany(p => p.Students)
                .WithMany(t => t.Courses)
                .UsingEntity<StudentCourses>(
                    j=>j
                    .HasOne(pt=>pt.Student)
                    .WithMany(t=>t.StudentCourses)
                    .HasForeignKey(pt=>pt.StudentId),

                    j=>j
                    .HasOne(pt => pt.Courses)
                    .WithMany(p=>p.StudentCourses)
                    .HasForeignKey(pt=>pt.CourseId),

                    j =>
                    {
                        j.HasKey(t => new { t.StudentId, t.CourseId });
                    }
                );

            modelBuilder.Entity<StudentCourses>().HasData(
                new {Id = 1, StudentId = 1, CourseId = 1 },
                new {Id = 2 , StudentId = 2, CourseId = 1},
                new { Id = 3, StudentId = 3, CourseId = 2 },
                new { Id = 4, StudentId = 4, CourseId = 2 }
                );

            modelBuilder.Entity<Courses>()
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Courses)
                .UsingEntity<TeacherCourses>(
                    j => j
                    .HasOne(pt => pt.Teacher)
                    .WithMany(t => t.TeacherCourses)
                    .HasForeignKey(pt => pt.TeacherId),

                    j => j
                    .HasOne(pt => pt.Courses)
                    .WithMany(p => p.TeacherCourses)
                    .HasForeignKey(pt => pt.CourseId),

                    j =>
                    {
                        j.HasKey(t => new { t.TeacherId, t.CourseId });
                    }
                );

            modelBuilder.Entity<TeacherCourses>().HasData(
                new { Id = 1, TeacherId = 1, CourseId = 1 },
                new { Id = 2, TeacherId = 2, CourseId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
