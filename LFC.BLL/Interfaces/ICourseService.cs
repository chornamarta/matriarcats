using System.Threading.Tasks;
using System.Collections.Generic;
using LFC.BLL.Models;

namespace LFC.BLL.Contracts
{
    public interface ICourseService
    {
        public Task CreateCourse(CreateCourseDto model);
        
        public Task DeleteCourse(DeleteCourseDto model);
    }
}