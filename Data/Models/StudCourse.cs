using Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class StudCourse
    {
        [Key, ForeignKey("StudId")]
        public Guid StudId { get; set; }
        public virtual Student Student { get; set; }

        [Key, ForeignKey("CourseId")]
        public Guid CourseId { get; set; }
        public virtual Courses Course { get; set; }

        public string CourseName { get; set; }
        public double Avarage { get; set; }
        public Semester Semester { get; set; }

        
    }
}