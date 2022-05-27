using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC.DAL.Models
{
    public enum Specialities
    {
        [Display(Name ="Комп'ютерні науки")]
        ComputerScience,

        [Display(Name = "Прикладна математика")]
        AppliedMathemetics,

        [Display(Name = "Системний аналіз")]
        SystemAnalysis,

        [Display(Name = "Кібербезпека")]
        Cybersecurity,

        [Display(Name = "Середня освіта.Інформатика")]
        Informatics,
    }

    public class Student
    {
        [Key]
        public int StudId { get; set; }

        [Display(Name = "Ім'я")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Прізвище")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Пошта")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Група")]
        [Required]
        public string Group { get; set; }
        
        [Display(Name = "Спеціальність")]
        [Required]
        [EnumDataType(typeof(Specialities))]
        public Specialities Specialities { get; set; }


        public ICollection<Courses> Courses { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
