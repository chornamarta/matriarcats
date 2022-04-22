using Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [Table("Courses")]
    public class Courses
    {
        [Key]
        public Guid CourseId { get; set; }
        [NotNull]
        public string CourseName { get; set; }
        [NotNull]
        public string Description { get; set; }
        [NotNull]
        public Semester Semester { get; set; }
        [NotNull]
        public Years Years { get; set; }
        [NotNull]
        public Specialities Specialities { get; set; }

        
        public Guid TeacherId  { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }


    }
}