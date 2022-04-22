using Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }
        public string FullName  { get; set; }
        public TeacherStatus TeacherStatus { get; set; }
        public string Password { get; set; }

    }
}