using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LFC.BLL.Contracts;
using LFC.BLL.Models;
using LFC.DAL.Contracts;
using LFC.DAL.Models;

namespace LFC.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Courses> _courseRepository;
        
        public CourseService(IRepository<Courses> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Courses>> GetCourses(string teacherId)
        {
            return ( await _courseRepository.FindAllAsync(c => c.Teachers.Any(t => t.UserId == teacherId))).ToList();
        }

        public async Task CreateCourse(string teacherId, CreateCourseDto model)
        {
            var course = new Courses()
            {
                CourseName = model.CourseName,
                CourseDescription = model.CourseDescription,
                Year = model.Year,
                Specialities = model.Specialities,
                Semester = model.Semester,
                Teachers = new Teacher[] { new Teacher() { UserId = teacherId } }
            };

            await _courseRepository.CreateAsync(course);
        }

        public async Task DeleteCourse(string teacherId, DeleteCourseDto model)
        {
            var course = await _courseRepository.FindEntityAsync(c => c.CourseId == model.CourseId, c => c.Teachers);

            if (course == null || !(course.Teachers?.Where(t => t.UserId == teacherId)).Any())
            {
                throw new Exception("Course not found or you dont have access to it");
            }

            await _courseRepository.Delete(course);
        }
    }
}