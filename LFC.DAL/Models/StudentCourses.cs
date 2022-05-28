using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC.DAL.Models
{
    public class StudentCourses
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }  

        public Student Student { get; set; }
        public Courses Courses { get; set; }
    }
}
