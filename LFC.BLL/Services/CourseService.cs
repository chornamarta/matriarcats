using System;
using System.Threading.Tasks;
using LFC.BLL.Contracts;
using LFC.BLL.Models;
using LFC.DAL.Models;

namespace LFC.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        
        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task CreateCourse(int teacherId, CreateCourseDto model)
        {
            var course = new Courses()
            {
                CourseName = model.CourseName,
                CourseDescription = model.CourseDescription,
                Year = model.Year,
                Specialities = model.Specialities,
                CourseDescription = model.CourseDescription,
                Semester = model.Semester,
                Teachers = new Teacher[] { new Teacher() { TeachId = teacherId } }
            };

            await _courseRepository.CreateAsync(course);
        }

        public async Task DeleteCourse(int teacherId, DeleteCourseDto model)
        {
            var course = await _courseRepository.FindEntityAsync(c => c.CourseId == model.CourseId, c => c.Teachers);

            if (course == null || course.Teachers?.Find(t => t.TeachId == teacherId) == null)
            {
                throw new Exception("Course not found or you dont have access to it");
            }

            await _courseRepository.Delete(course);
        }
    }
}