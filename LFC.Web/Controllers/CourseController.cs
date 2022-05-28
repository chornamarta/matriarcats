using System.Threading.Tasks;
using DataAccess.Entities;
using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LFC.BLL.Contracts;

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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCourseDto model)
        {
            var teacherId = HttpContext.User.FindFirst("Id")?.Value;

            if (!ModelState.IsValid)
            {
                return Redirect("/courses/create");
            }
            
            await _courseService.CreateCourse(teacherId, model);
            
            return Redirect("тут має бути редірект кудись");
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteCourseDto model)
        {
            var teacherId = HttpContext.User.FindFirst("Id")?.Value;

            if (!ModelState.IsValid)
            {
                return Redirect("тут має бути редірект кудись");
            }
            
            await _courseService.DeleteCourse(teacherId, model);
            
            return Redirect("тут має бути редірект кудись");
        }
    }
}