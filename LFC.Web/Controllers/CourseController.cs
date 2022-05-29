using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LFC.BLL.Contracts;
using LFC.BLL.Models;

namespace LFC.Web.Controllers
{
    [Route("api/courses")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var teacherId = HttpContext.User.FindFirst("Id")?.Value;
            return View(await _courseService.GetCourses(teacherId));
        }
        
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCourseDto model)
        {
            var teacherId = HttpContext.User.FindFirst("Id")?.Value;

            if (!ModelState.IsValid)
            {
                return Redirect("/course/create");
            }
            
            await _courseService.CreateCourse(teacherId, model);
            
            return Redirect("/course");
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteCourseDto model)
        {
            var teacherId = HttpContext.User.FindFirst("Id")?.Value;

            if (!ModelState.IsValid)
            {
                return Redirect("/courses");
            }
            
            await _courseService.DeleteCourse(teacherId, model);
            
            return Redirect("/courses");
        }
    }
}