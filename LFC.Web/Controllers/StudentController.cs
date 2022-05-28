using LFC.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LFC.Web.Controllers
{ 
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        public IActionResult Index() =>
            Content("Student");
        
    }
}