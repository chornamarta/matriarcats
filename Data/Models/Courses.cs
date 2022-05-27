using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC.DAL.Models
{
    public enum Semester
    {
        [Display(Name = "1 семестр")]
        FirstSemester,

        [Display(Name = "2 семестр")]
        SecondSemester
    }
    public enum Year
    {
        [Display (Name = "3")]
        Third,

        [Display(Name = "4")]
        Fourth
    }
    
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Display(Name = "Назва курсу")]
        [Required]
        public string CourseName { get; set; }

        [Display(Name = "Опис курсу")]
        [Required]
        public string CourseDescription { get; set; }

        [Display(Name = "Курс")]
        [Required]
        [EnumDataType(typeof(Year))]
        public Year Year { get; set; }

        [Display(Name = "Семестр")]
        [Required]
        [EnumDataType(typeof(Semester))]
        public Semester Semester { get; set; }

        [Display(Name = "Спеціальність")]
        [Required]
        [EnumDataType(typeof(Specialities))]
        public Specialities Specialities { get; set; }


        public ICollection<Student> Students { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<TeacherCourses> TeacherCourses { get; set; }
        
    }
}
