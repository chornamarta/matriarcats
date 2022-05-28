using System.Threading.Tasks;
using System.Collections.Generic;
using LFC.BLL.Models;
using LFC.DAL.Models;

namespace LFC.BLL.Contracts
{
    public interface ICourseService
    {
        public Task CreateCourse( string userId, CreateCourseDto model);
        
        public Task DeleteCourse( string userId, DeleteCourseDto model);

        public Task<List<Courses>> GetCourses(string teacherId);
    }
}