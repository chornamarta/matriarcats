using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC.DAL.Models
{
    public class TeacherCourses
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public Teacher Teacher { get; set; }
        public Courses Courses { get; set; }
    }
}
