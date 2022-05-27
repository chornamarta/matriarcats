using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC.DAL.Models
{
    public enum TeacherRole
    {
        [Display(Name = "Кандидат наук")]
        PhD,

        [Display(Name = "Доктор наук")]
        PHD,

        [Display(Name = "Доцент")]
        Docent,

        [Display(Name = "Старший викладач")]
        SeniorLecturer,

        [Display(Name = "Професор")]
        Proffesor,
    }

    public class Teacher
    {
        [Key]
        public int TeachId { get; set; }

        [Required]
        [Display(Name ="Прізвище та ім'я")]
        public string FullName { get; set; }

        [Required]
        [Display(Name ="Ступінь")]
        [EnumDataType(typeof(TeacherRole))]
        public TeacherRole TeacherRole { get; set; }

        [Required]
        [Display(Name = "Пошта")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        public ICollection<Courses> Courses { get; set; }
        public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
