using System;
using System.ComponentModel.DataAnnotations;

namespace LFC.BLL.Models
{
    public class DeleteCourseDto
    {
        [Required]
        public int CourseId;
    }
}