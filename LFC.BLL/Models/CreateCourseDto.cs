using System;
using System.ComponentModel.DataAnnotations;
using LFC.DAL.Models;

namespace LFC.BLL.Models
{
    public class CreateCourseDto
    {
        [Required]
        public string CourseName;
        [Required]
        public string CourseDescription;
        [Required]
        public Year Year;
        [Required]
        public Specialities Specialities;
        [Required]
        public Semester Semester;
    }
}